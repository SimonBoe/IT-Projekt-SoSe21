using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Scraper : MonoBehaviour
{
    // create public refs to lesson room, name and teacher info
    [SerializeField]
    private Text lessonRoom;
    [SerializeField]
    private Text lessonName;
    [SerializeField]
    private Text lessonTeacher;

    string scraping_output;

    void Start()
    {
        StartCoroutine(GetText());
        // findCourseLink(read_string, "3B8D64DB-2846-48D0-AB9E-782225E7B613"); // z.B. MuK1-3a
        // findCourseLink(read_string, "MuK1-3a"); // z.B. MuK1-3a
    }

    string findCourseLink(string scrapedText, string courseName)
    {
        // string week = "0";
        // string regexPattern = @"https?.*" + courseID + "&week=" + week; // with ID
        string regexPattern = @"https?.*" + "(?=\">" + courseName + ")";
        Debug.Log(Regex.Match(scrapedText, regexPattern));
        return "";
    }

    string extractTimeTable(string scrapedText)
    {
        string pattern = @"<table class=""timetable"">(.*\n)*<\/table>";
        string matched = Regex.Match(scrapedText, pattern).ToString();

        return matched;
    }

    string extractDayAndPosition(string scrapedText, string day, string pos)
    {
        string pattern = @"<!-- " + day + " " + pos + @" -->(.*\n)*?<\/table>";
        string matched = Regex.Match(scrapedText, pattern).ToString();

        return matched;
    }

    void setLessonInfo(string text)
    {
        // string[] res = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        string subjectPattern = @"(?<=<div class=""lesson-subject"">.*\n).*";
        string subjectMatched = Regex.Match(text, subjectPattern).ToString();

        string teacherPattern = @"(?<=<div class=""lesson-teacher"">.*\n).*";
        string teacherMatched = Regex.Match(text, teacherPattern).ToString();

        // Setting text in canvas
        lessonRoom.text = "Room D-205";
        lessonName.text = subjectMatched;
        lessonTeacher.text = "by " + teacherMatched;
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=3B8D64DB-2846-48D0-AB9E-782225E7B613&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Handle incoming html data
            string htmlText = www.downloadHandler.text;

            string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            setLessonInfo(text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }
}

