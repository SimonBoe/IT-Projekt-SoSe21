using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class Scraper : MonoBehaviour
{
    // create public refs to lesson room, name and teacher info
    [SerializeField]
    private Text[] lessonRooms;
    [SerializeField]
    private Text[] lessonNames;
    [SerializeField]
    private Text[] lessonTeachers;

    string scraping_output;

    void Start()
    {
        StartCoroutine(GetText());
        StartCoroutine(GetText1());
        StartCoroutine(GetText2());
        StartCoroutine(GetText3());
        StartCoroutine(GetText4());
        StartCoroutine(GetText5());
        StartCoroutine(GetText6());
        StartCoroutine(GetText7());
        StartCoroutine(GetText8());
        StartCoroutine(GetText9());
        StartCoroutine(GetText10());
        StartCoroutine(GetText11());
        StartCoroutine(GetText12());
        StartCoroutine(GetText13());
        StartCoroutine(GetText14());
        StartCoroutine(GetText15());
        StartCoroutine(GetText16());
        StartCoroutine(GetText17());
        StartCoroutine(GetText18());
        StartCoroutine(GetText19());
        StartCoroutine(GetText20());
        StartCoroutine(GetText21());
        StartCoroutine(GetText22());
        StartCoroutine(GetText23());
        StartCoroutine(GetText24());
        StartCoroutine(GetText25());
        StartCoroutine(GetText26());
        StartCoroutine(GetText27());
        StartCoroutine(GetText28());
        StartCoroutine(GetText29());
        StartCoroutine(GetText30());
        StartCoroutine(GetText31());
        StartCoroutine(GetText32());
        StartCoroutine(GetText33());
        StartCoroutine(GetText34());
        StartCoroutine(GetText35());
        StartCoroutine(GetText36());
        StartCoroutine(GetText37());
        // StartCoroutine(GetText3());
        // StartCoroutine(GetText4());
        
        // TODO: Get date and time, important for chosing the right position in time table
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

    void setLessonInfo(int textPos, string text)
    {
        // string[] res = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        string subjectPattern = @"(?<=<div class=""lesson-subject"">.*\n).*";
        string subjectMatched = Regex.Match(text, subjectPattern).ToString();

        string teacherPattern = @"(?<=<div class=""lesson-teacher"">.*\n).*";
        string teacherMatched = Regex.Match(text, teacherPattern).ToString();

        // Setting text in canvas
        lessonRooms[textPos].text = "Room D-205";
        lessonNames[textPos].text = subjectMatched;
        lessonTeachers[textPos].text = "by " + teacherMatched;
    }

    IEnumerator GetText()
    {
        // Link for Muk1-3a
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=3B8D64DB-2846-48D0-AB9E-782225E7B613&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 1 finished");

            // Handle incoming html data
            //string htmlText = www.downloadHandler.text;

            //string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            //setLessonInfo(0, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText1()
    {
        // Link for Muk1-3b
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=590C74F0-0B32-4955-908C-A80AA9A6DF92&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 2 finished");

            // Handle incoming html data
            //string htmlText = www.downloadHandler.text;

            //string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            //setLessonInfo(1, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText2()
    {
        // Link for MI1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=2086AB94-BDCB-4AB4-B20E-B92BF848FC8C&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 3 finished");

            // Handle incoming html data
            //string htmlText = www.downloadHandler.text;

            //string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            //setLessonInfo(2, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText3()
    {
        // Link for MI2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=7343F79C-D1ED-4FCE-BF60-96104B48760E&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 4 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(3, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText4()
    {
        // Link for MI3
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=956101DC-2995-4241-A784-982ADCB523C1&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 5 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(4, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText5()
    {
        // Link for MI4-7a
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=13093B44-B3D7-4DAB-A56B-9DD3ACF28734&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 6 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(5, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText6()
    {
        // Link for MI4-7b
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=817F3F8C-C889-454F-8585-6D94FCB2647A&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 7 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(6, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText7()
    {
        // Link for MI4-7c
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=05C960F0-A85F-4EDD-B682-19575F6A76CD&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 8 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(7, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText8()
    {
        // mgp1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=E3A618EE-96C1-45CE-A70E-EE7F8830EA04&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 9 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(8, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText9()
    {
        // mgp2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=A36AFD23-0B5E-4444-B0D0-4C38181F8048&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 10 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(9, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText10()
    {
        // mgp3
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=808A84FA-D3EF-496A-AA4B-C7E7F33E0BDB&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 11 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(10, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText11()
    {
        // mgp4-7a
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=4A5E1652-10AE-48BA-8680-AC515C8BAEE9&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 12 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(11, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText12()
    {
        // mgp4-7b
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=88BBB4A5-4D22-4C27-8A89-B8C7B872A25A&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 13 finished");

            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(12, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText13()
    {
        // MW-plus1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=22EA376D-3F88-44FA-A6B4-CCDEB0220F22&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 14 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(13, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText14()
    {
        // MW-plus2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=2D128734-7E8A-435F-B3D0-5C9370C73359&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 15 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(14, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText15()
    {
        // MW-plus3
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=1649AFB7-C2EB-4624-B617-F702736C5FDD&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 16 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(15, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText16()
    {
        // MW-plus4
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=921B75FB-7400-43ED-8FEE-591497A38C3B&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 17 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(16, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText17()
    {
        // MW-plus5
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=8F233F22-121E-4D81-900B-403BA8767FEC&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 18 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(17, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText18()
    {
        // MW-plus6
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=3462A888-0F03-4D44-BC9E-CC607D82FCE0&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 19 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(18, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText19()
    {
        // MW-plus7
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=C9633681-C9DF-4A25-915C-F178FA4FEE0C&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 20 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(19, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText20()
    {
        // MW-plus3-7
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=E0213A9A-CB13-4B14-8F1E-60B0DC398A7F&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 21 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(20, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText21()
    {
        // UN1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=ADA03BB0-4372-4A8D-B6EB-C279D68B99C7&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 22 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(21, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText22()
    {
        // UN2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=D1F5DF8A-2720-44B7-8ED3-C815E29F59D7&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 23 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(22, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText23()
    {
        // UN3
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=AA155E94-E6BC-468C-8A89-6D3B0CCB7C07&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 24 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(23, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText24()
    {
        // UN4
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=8A22B087-7EEA-4373-AA16-CE947EC2161B&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 25 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(24, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText25()
    {
        // UN5
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=7EC52BA0-A8EB-4285-814D-764FD1B38AF6&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 26 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(25, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText26()
    {
        // UN6
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=A88FBD69-9459-4B04-AAF0-3FD8EF3B16E4&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 27 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(26, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText27()
    {
        // UN7
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=BE94A41C-2013-46F8-A9BA-61672508F6F3&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 28 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(27, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText28()
    {
        // UN4-7
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=EF7A975F-3F6F-4E42-9F6F-94C0810F09BA&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 29 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(28, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText29()
    {
        // CME1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=6F219938-A197-48BF-884B-7C43622562AD&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 30 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(29, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText30()
    {
        // CME2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=A88AC279-55D5-4B3B-8037-9C4F5FA0876B&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 31 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(30, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText31()
    {
        // CME3
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=3ACC88F4-9D89-4EA5-B5CD-F27EA0DCB709&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 32 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(31, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText32()
    {
        // ENITS1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=35EF05E8-58EA-4D13-9CEE-DD0B690B00DB&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 33 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(32, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText33()
    {
        // ENITS2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=F49D54D1-F50A-447F-B0D1-DA8FC4FCC65A&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 34 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(33, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText34()
    {
        // DEC1-2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=372E2109-04E4-4F3E-827A-8330271DD1AC&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 35 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(34, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText35()
    {
        // MWBB1
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=17E31406-1EA2-4A51-BD43-D97FDA5B41EC&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 36 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(35, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText36()
    {
        // MWBB2
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=AC8B0B76-31D3-466F-9896-45787B1BE62F&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 37 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(36, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetText37()
    {
        // MWBB3
        UnityWebRequest www = UnityWebRequest.Get("https://www.hs-offenburg.de/index.php?id=6627&class=class&iddV=B3394275-DF6A-4C9A-ADE1-0357148F96A5&week=0");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request 38 finished");
            // Handle incoming html data
            // string htmlText = www.downloadHandler.text;

            // string text = extractDayAndPosition(extractTimeTable(htmlText), "Mi", "1");
            // setLessonInfo(37, text);

            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }
    }
}

