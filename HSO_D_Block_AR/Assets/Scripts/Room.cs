using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [SerializeField]
    private GameObject moreInfoBtnParent;
    private Button moreInfoBtn;

    [SerializeField]
    private string roomName;
    [SerializeField]
    private GameObject liveIndicator;
    [SerializeField]
    private Text infoBox;
    // Store today's lessons
    private List<RoomInformation> roomLessons = new List<RoomInformation>();
    // Store specific lesson info
    private List<string> lessonInfo = new List<string>();
    private int timeBlock = 0;

    private string furtherInfo = default;

    // Start is called before the first frame update
    void Start()
    {
        if (Scraper.Instance) 
        {
            if (Scraper.Instance.roomInfoDict.ContainsKey(roomName)) {
                roomLessons = Scraper.Instance.roomInfoDict[roomName];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // first make some sanity checks
        if (roomLessons.Count == 0 || TimeManager.TimeToBlock() == -1) return;

        // check for info for current time block
        int currentTimeBlock = TimeManager.TimeToBlock();

        // only do stuff if time block has changed
        if (currentTimeBlock != timeBlock) 
        {
            // reset lesson info list
            lessonInfo = new List<string>();

            foreach (var lesson in roomLessons)
            {
                if (lesson.TimeBlock == currentTimeBlock) {
                    // activate live indicator icon
                    liveIndicator.SetActive(true);
                    // store current lesson info
                    lessonInfo.Add(lesson.Course);
                    lessonInfo.Add(lesson.LessonSubject);
                    lessonInfo.Add(lesson.LessonTeacher);
                    lessonInfo.Add(lesson.LessonRemark);
                    return;
                } 
                else {
                    liveIndicator.SetActive(false);
                }
            }
        }
        timeBlock = currentTimeBlock;
    }

    public void OnButtonPressed() {
        // set room info text
        if (lessonInfo.Count == 0) {
            infoBox.text = $"No current events in the room.";
        } else {
            infoBox.text = $"Event:\n{lessonInfo[0]}{lessonInfo[1].TrimEnd()}{lessonInfo[2].TrimEnd()}{lessonInfo[3].TrimEnd()}";
        }

        if (InfoManager.MoreInfo.ContainsKey(roomName)) {
            // show more info button and transfer link
            moreInfoBtnParent.SetActive(true);
            moreInfoBtn = moreInfoBtnParent.GetComponent<Button>();
		    moreInfoBtn.onClick.AddListener(ShowMoreInfo);
        } else {
            moreInfoBtnParent.SetActive(false);
        }
    }

    public void ShowMoreInfo() {
        string url = InfoManager.MoreInfo[roomName];
        Application.OpenURL(url);
    }
}