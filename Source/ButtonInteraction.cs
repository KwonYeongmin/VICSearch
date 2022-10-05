using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Animator>().enabled=false;
    }

    public void PointerDown()
    {
        int idx = this.GetComponent<Marker>().Index;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraScene>().SetIndex(idx);
    }


}
