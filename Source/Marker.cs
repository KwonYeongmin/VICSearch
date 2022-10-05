using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public int Index;
    public bool bRecognized { get; private set; }

    private void Start()
    {
        bRecognized = false;
    }

    public void SetBool(bool b)
    {
        Debug.Log(Index);
        bRecognized = b; }
}
