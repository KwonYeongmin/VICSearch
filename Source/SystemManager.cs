using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    private static SystemManager instance = null;
   

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //
        Display = 5;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public static SystemManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // ===============================================================================

    public GenreData genreData { get; private set; }
    public string KeywordText { get; private set; }
    public int Display { get; private set; }

    public void SetGenre(int idx, string key)
    {
        genreData = new GenreData(idx,key);
    }

    public void ChangeScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }

    public void SetQuery(string str)
    {
        KeywordText = str;
    }
}
