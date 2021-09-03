using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        //Debug.Log("J'ai Cliqué " + gameObject.name);
        Player_Controller doGoto = myPlayer.gameObject.GetComponent<Player_Controller>();
        doGoto.isClickeed(gotoPosition.transform);

        if(gotoPosition.tag == "Thief")
        {
            Debug.Log("Thief");
        }

    }
}

