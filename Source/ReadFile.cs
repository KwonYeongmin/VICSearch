using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadFile : MonoBehaviour
{
    
    private List<GenreData> genreDatas = new List<GenreData>();

    private void Start()
    {
        ReadFileFunc();
    }

    public void ReadFileFunc()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/genreData.csv");
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            TextAsset data = Resources.Load("genreData.csv") as TextAsset;
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');

            for (int i = 0; i < data_values.Length/2; i+=2)
            {
                genreDatas.Add(new GenreData(int.Parse(data_values[i].ToString()) - 1, data_values[i + 1].ToString()));
            }
        }

        
    }

    public void Print()
    {
        for (int i = 0; i < genreDatas.Count; i++)
        {
           Debug.Log("index : " + genreDatas[i].Index +" ,keyword :"+ genreDatas[i].Keyword);
        }
    }

    public string GetKeyword(int idx)
    {
        return genreDatas[idx].Keyword;
    }
}
