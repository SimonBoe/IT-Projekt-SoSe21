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
    public static Scraper Instance;

    void Start()
    {
        if (Instance == null) {
            Instance = this;
        }
        // Setup the time table within helper class
        TimeManager.SetupTimeTable();
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

public static class TimeManager {
    
    public class LessonTime {
        public DateTime Start;
        public DateTime End;
    }

    // Store timetable info within dictionary, key: block no, value: tuple of two time measures
    public static Dictionary<int, LessonTime> timeTable; 

    public static void SetupTimeTable() {
        timeTable = new Dictionary<int, LessonTime>() {
            [1] = (new LessonTime { Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 30, 0)}),
            [2] = (new LessonTime { Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 30, 0), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 11, 15, 0)}),
            [3] = (new LessonTime { Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 11, 35, 0), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 13, 5, 0)}),
            [4] = (new LessonTime { Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 14, 0, 0), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 15, 30, 0)}),
            [5] = (new LessonTime { Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 15, 45, 0), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 15, 0)}),
            [6] = (new LessonTime { Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 30, 0), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 19, 0, 0)}),
        };
    }

    public static int TimeToBlock() {
        DateTime now = DateTime.Now;
        
        foreach (var block in timeTable)
        {
            DateTime start = block.Value.Start;
            DateTime end = block.Value.End;

            if (now >= start && now < end) {
                return block.Key;
            }
        }

        // Currently no lesson taking place
        return -1;
    }

    public static DateTime GetCurrentTime() {
        return DateTime.Now; // maybe change to UTC time later!
    }
}