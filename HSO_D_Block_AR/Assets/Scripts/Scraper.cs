using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class Scraper : MonoBehaviour
{
    // Create public dictionary with room info
    public Dictionary<string, List<RoomInformation>> roomInfoDict;

    void Start()
    {
        StartCoroutine(GetRoomInfo());
    }

    IEnumerator GetRoomInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://hsoarapp.blob.core.windows.net/scrape-output/result.json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            roomInfoDict = JsonConvert.DeserializeObject<Dictionary<string, List<RoomInformation>>>(json);
        }
    }
}

[Serializable]
public class RoomInformation
{
    public int TimeBlock { get; set; }
    public string Course { get; set; }
    public string LessonSubject { get; set; }
    public string LessonTeacher { get; set; }
    public string LessonRemark { get; set; }
}