using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentScene : MonoBehaviour
{
    // title, subtitle, image, director, userrating, actor

    [Header("외적 ")]
    public GameObject[] Units;// = new GameObject[5];
    private TextMeshProUGUI[] Title;
    private TextMeshProUGUI[] URL;
    private TextMeshProUGUI[] SubTitle;
    private TextMeshProUGUI[] Year;
    private TextMeshProUGUI[] Director;
    private TextMeshProUGUI[] UserRating;
    private TextMeshProUGUI[] Actor;
    private TextMeshProUGUI[] link;
    private RawImage[] Thumbnail;
    public TextMeshProUGUI ErrorTXT;
    private int display = 5;

    private void Awake()
    {
        Title = new TextMeshProUGUI[5];
        URL = new TextMeshProUGUI[5];
        SubTitle = new TextMeshProUGUI[5];
        Director = new TextMeshProUGUI[5];
        UserRating = new TextMeshProUGUI[5];
        Actor = new TextMeshProUGUI[5];
        Year = new TextMeshProUGUI[5];
        link = new TextMeshProUGUI[5];
        Thumbnail = new RawImage[5];

        for (int i = 0; i < 5; i++)
        {
            Thumbnail[i]=Units[i].transform.GetChild(0).GetComponent<RawImage>();
            Title[i]=Units[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            Year[i]=Units[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            SubTitle[i]=Units[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            UserRating[i]=Units[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>();
            Director[i]=Units[i].transform.GetChild(5).GetComponent<TextMeshProUGUI>();
            Actor[i]= Units[i].transform.GetChild(6).GetComponent<TextMeshProUGUI>();
            link[i] = Units[i].transform.GetChild(7).GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        Reset();
    }

    public void Setting(List<Item> items)
    {
        for (int i = 0; i < display; i++)
        {
            Title[i].text =string.Format("제목 :{0}",items[i].title);
            Year[i].text = items[i].pubData.ToString();
            SubTitle[i].text = items[i].subtitle;
            UserRating[i].text = string.Format("평점 : {0}", items[i].userRating.ToString());
            Director[i].text = string.Format("감독 : {0}", items[i].director);
            Actor[i].text = string.Format("배우 : {0}",items[i].actor);
            link[i].text = items[i].link.ToString();

            GetImageTexture(items[i].image, Thumbnail[i]);
        }
    }

    private void ToggleContent(bool b)
    {
        for (int i = 0; i < 5; i++)
        {
            Thumbnail[i].gameObject.SetActive(b);
            Title[i].gameObject.SetActive(b);
            Year[i].gameObject.SetActive(b);
            SubTitle[i].gameObject.SetActive(b);
            UserRating[i].gameObject.SetActive(b);
            Director[i].gameObject.SetActive(b);
            Actor[i].gameObject.SetActive(b);
            link[i].gameObject.SetActive(b);
        }
       
    }

    private void Reset()
    {
        ErrorTXT.gameObject.SetActive(false);
    }

    private void GetImageTexture(string thumbUrl, RawImage image)
    {

        StartCoroutine(GetImageFromUrl(thumbUrl, image));
    }

    private IEnumerator GetImageFromUrl(string url, RawImage img)
    {
        WWW www = new WWW(url);
        yield return www;
        
        img.texture = www.texture;
    }


    public void ShowError()
    {
        // 에러메시지 띄우기
        ErrorTXT.gameObject.SetActive(true);
    }

    public void ClickURL(GameObject obj)
    {
       Application.OpenURL(obj.GetComponent<TextMeshProUGUI>().text.ToString());
    }
}
