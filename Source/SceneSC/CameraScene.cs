using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CameraScene : MonoBehaviour
{
    [Header("선택 윈도우")]
    public GameObject SelectionWindow;
    public GameObject Panel;
    [Header("카메라")]
    public Camera[] cams;
    [Header("스프라이트")]
    public Sprite[] genre_sprite;


    [Header("panel")]
    public GameObject Basepanel;
    public GameObject CameraFrame;
    [Header("scroll")]
    public GameObject ScrollPanel;
    public GameObject ScrollText;
    [Header("imagesensing")]
    public GameObject GenreSinglePanel;
    public Image KeywordImg;
    public TextMeshProUGUI KeywordTXT;
    private GameObject[] Markers = new GameObject[13];
    private int RecognizedMarker = 0;

    private int length = 28;
    private ReadFile Reader;

    private Color[] colors;



    private void Start()
    {
        SelectionWindow.SetActive(true);
        Panel.SetActive(true);

        Reader = this.GetComponent<ReadFile>();
        Reset();
        Markers = GameObject.FindGameObjectsWithTag("Marker");
        
    }

    public void Reset()
    {
        //color
        
        //cam
        cams[1].enabled = true;

        // panel
        ScrollPanel.SetActive(false);
        ScrollText.SetActive(false);
        GenreSinglePanel.SetActive(false);

        // scroll
        Basepanel.GetComponent<ScrollRect>().enabled = false;

        //
        KeywordImg.GetComponent<Animator>().enabled = false;

        //
        EnablePress = false;
    }



    // imagesesing
    public void PressImgsensingBtn()
    {
        SelectionWindow.SetActive(false);
        Panel.SetActive(false);
        GenreSinglePanel.SetActive(true);
        CameraFrame.SetActive(true);
    }

    public void SetIndex()
    {
        foreach (GameObject marker in Markers)
        {
            if (marker.GetComponent<Marker>().bRecognized)
            {
                RecognizedMarker = marker.GetComponent<Marker>().Index;
                // 이미지
                KeywordImg.sprite = genre_sprite[RecognizedMarker];
                KeywordImg.GetComponent<Animator>().enabled = true;
                // 텍스트
                KeywordTXT.text = Reader.GetKeyword(RecognizedMarker);
                //
                EnablePress = true;
            }
        }
    }

    private bool EnablePress=false;


    public void PressKeywordBtn()
    {
        SystemManager.Instance.SetGenre(RecognizedMarker+1, Reader.GetKeyword(RecognizedMarker));
        SystemManager.Instance.ChangeScene(2);
    }


    public void SetIndex(int idx)
    {
        RecognizedMarker = idx;
        PressKeywordBtn();
    }


    // scroll
    public void PressButtonBtn()
    {
        SelectionWindow.SetActive(false);
        Panel.SetActive(false);
        cams[1].enabled = false;
        ScrollPanel.SetActive(true);
        ScrollText.SetActive(true);

        // scroll 가능
        CameraFrame.SetActive(false);
        Basepanel.GetComponent<ScrollRect>().enabled = true;
        InstantiateGenreImg();
        Basepanel.GetComponent<Image>().color = new Color(1,0.9f,0.6f);
    }


    [Header("Scroll Prefab")]
    public GameObject ImgPrefab;
    private List<GameObject> ScrollImgs= new List<GameObject>();

    private void InstantiateGenreImg()
    {
        for (int i = 0; i < length; i++)
        {
            // 생성
            GameObject obj = Instantiate(ImgPrefab, ScrollPanel.transform);
            //부모 설정
            obj.transform.SetParent(ScrollPanel.transform);
            // 이미지 
            obj.GetComponent<Image>().sprite = genre_sprite[i];
            // 키워드
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Reader.GetKeyword(i);
            //list에 추가 
            ScrollImgs.Add(obj);
        }
    }

}
