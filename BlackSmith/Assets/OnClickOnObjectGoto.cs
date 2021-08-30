using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickOnObjectGoto : MonoBehaviour
{
    public GameObject gotoPosition;
    public GameObject myPlayer;

    void Start()
    {
       // gotoPosition = gameObject;

    }
        
    void OnMouseDown()
    {
        {
            Debug.Log("J'ai Cliqué " + gameObject.name);
            PlayerMovement doGoto = myPlayer.gameObject.GetComponent<PlayerMovement>();
            doGoto.isClickeed(gotoPosition.transform);
        }
    }
}

