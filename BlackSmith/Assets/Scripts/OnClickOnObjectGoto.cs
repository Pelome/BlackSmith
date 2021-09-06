using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickOnObjectGoto : MonoBehaviour
{
    public GameObject gotoPosition;
    public GameObject myPlayer;
    public int step;
    public GameObject currentObjectToForge;


    void Start()
    {
       // gotoPosition = gameObject;
    }
        
    //public void OnMouseDown()
    public void itemIsClicked()
    {
        //Debug.Log("J'ai Cliqué " + gameObject.name);
        Player_Controller doGoto = myPlayer.gameObject.GetComponent<Player_Controller>();
        doGoto.isClickeed(gotoPosition.transform);
/*        if(doGoto.facingRight == true)
        {
            doGoto.flip();
        }*/


        if(gotoPosition.tag == "Thief")
        {
            Debug.Log("Thief");
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if(other.tag == "Player")
        {

            if(other.GetComponent<Player_Controller>().isMoving == false && other.GetComponent<Player_Controller>().isAtDestination == false)
            {
                other.GetComponent<Player_Controller>().isAtDestination = true;
                Debug.Log("Arrivé");
                currentObjectToForge = GameObject.Find("ObjectToForge(Clone)");
                
                if (currentObjectToForge == null)
                {
                    Instantiate(other.GetComponent<Player_Controller>().objectToForgePrefab,other.GetComponent<Player_Controller>().objectToForgeSlot.transform);
                    currentObjectToForge = other.GetComponent<Player_Controller>().objectToForgePrefab;
                }

                if (currentObjectToForge != null)
                {
                    currentObjectToForge.GetComponent<ObjectToForge_Controller>().GoNextStep();
                }


            }
        }
    }




}

