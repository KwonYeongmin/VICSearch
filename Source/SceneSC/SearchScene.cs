using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchScene : MonoBehaviour
{
    public TextMeshProUGUI InputText;
   // public string KeywordText { get; private set; }

    public void SaveText()
    {
        SystemManager.Instance.SetQuery(InputText.text);
        SystemManager.Instance.ChangeScene(3);
    }
}
