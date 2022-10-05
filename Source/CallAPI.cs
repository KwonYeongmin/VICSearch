using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Converters;
using System.Globalization;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class CallAPI : MonoBehaviour
{
    // =============================================================================


    string API_ClientID = "8pTCnHoWQqB9E2BNVErp";
    string API_ClientSecret = "6I7MiPYIbp";
    string site = "https://openapi.naver.com/v1/search/movie.json";
    // public int display = 5;
    ContentScene contentScene;
    public List<Item> items = new List<Item>();

    // =============================================================================

    private void Start()
    {
        contentScene = this.GetComponent<ContentScene>();
        CallAPIFunc();
    }
 
    [Header("Test")]

    public string Key_test;
    public int genre_test;



    public void CallAPIFunc()
    {
        var requestResult = string.Empty;

        try
        {
            WebRequest request = null;
            string keyword = SystemManager.Instance.KeywordText;
            int genre = SystemManager.Instance.genreData.Index;
            int display = SystemManager.Instance.Display;

            string url = string.Format("{0}?query={1}&display={2}&start=1&genre={3}", site, keyword, display, genre);
            request = WebRequest.Create(url);

            request.Headers.Add("X-Naver-Client-Id", API_ClientID);
            request.Headers.Add("X-Naver-Client-Secret", API_ClientSecret);

            WebResponse response = request.GetResponse();
            Stream dataStream = null;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
            requestResult = reader.ReadToEnd();

            //
            //to do something
            Temperatures temp = JsonUtility.FromJson<Temperatures>(requestResult.ToString());
            if (temp != null)
            {
                for (int i = 0; i < display; i++)
                {
                    items.Add(temp.items[i]);
                }
            }
            contentScene.Setting(items);
            //



            reader.Close();
            dataStream.Close();
            response.Close();

        }
        catch (Exception ex)
        {
            Debug.Log("Exception occurred!");
            contentScene.ShowError();
        }

    }  

}




// =============================================================================


[System.Serializable]
public class Temperatures
{
    public Item[] items;
    public Parameter param;
}

[System.Serializable]
public class Parameter
{
    public string query;
    public int display;
    public int start;
    public string genre;
    public string country;
    public int yearfrom;
    public int yearto;
}

[System.Serializable]
public class Item
{
    public string title;
    public string link;
    public string image;
    public string subtitle;
    public int pubData;
    public string director;
    public string actor;
    public int userRating;

}






