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
        doGoto.isClickeed(gotoPosition.transform, gotoPosition.transform.parent.gameObject);
        return;
/*        if(doGoto.facingRight == true)
        {
            doGoto.flip();
        }*/


        if(gotoPosition.tag == "Thief")
        {
            Debug.Log("Thief");
            //frapper le voleur si il a volé quelque chose
        }
    }

    //void OnTriggerStay2D (Collider2D other)
    public void IamAtDestination()
    {
        Player_Controller doGoto = myPlayer.gameObject.GetComponent<Player_Controller>();
        currentObjectToForge = GameObject.Find("ObjectToForge(Clone)");  
        if (currentObjectToForge != null)
        {
            ObjectToForge_Controller objectToCraftScript = currentObjectToForge.GetComponent<ObjectToForge_Controller>();
            Debug.Log("Item Step : " + objectToCraftScript.currentStep + " | InterractibleObjectStep : " + step + " | StepSuivant : " + objectToCraftScript.steps[objectToCraftScript.currentStep +1] );
            if(objectToCraftScript.steps[objectToCraftScript.currentStep] == objectToCraftScript.steps.Length)
            {
                objectToCraftScript.GoNextStep();   
            }

            if(objectToCraftScript.steps[objectToCraftScript.currentStep +1] == step)
            {
                objectToCraftScript.GoNextStep();
            }
        }
        if(gameObject.tag == "Cart")
        {
            if (currentObjectToForge == null)
            {
                Instantiate(doGoto.objectToForgePrefab,doGoto.objectToForgeSlot.transform);
                currentObjectToForge = doGoto.objectToForgePrefab;
                Debug.Log("GoNextStep");
            }
        }
        if(gameObject.tag == "FireBowl")
        {  
        }
        if(gameObject.tag == "Anvil")
        { 
        }
        if(gameObject.tag == "Barrel")
        {  
        }
        if(gameObject.tag == "Stash")
        { 
            //put in stash

        }
        if(gameObject.tag == "Pannel")
        { 
        }                
        if(gameObject.tag == "Horse")
        {  
        }
    }
}

