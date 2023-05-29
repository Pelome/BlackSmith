using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickOnObjectGoto : MonoBehaviour
{
    public GameObject gotoPosition;
    public GameObject myPlayer;
    public int stepValue;
    public GameObject currentObjectToForge;

    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player"); 
    }
        
    public void itemIsClicked()
    {
        Debug.Log("J'ai cliqué sur : " + gameObject.name + " son index est: "+ stepValue);
        Player_Controller doGoto = myPlayer.gameObject.GetComponent<Player_Controller>();
        doGoto.isClickeed(gotoPosition.transform, gotoPosition.transform.parent.gameObject);
        return;
    }

    public void IamAtDestination()
    {
        Player_Controller doGoto = myPlayer.gameObject.GetComponent<Player_Controller>();
        currentObjectToForge = GameObject.FindWithTag("ObjectToForge");  
        if (currentObjectToForge != null)
        {
            GameManager.instance.stepToGo = 0;
            ObjectToForge_Controller objectToCraftScript = currentObjectToForge.GetComponent<ObjectToForge_Controller>();
            objectToCraftScript.GoNextStep(stepValue);
           /* if((objectToCraftScript.steps[objectToCraftScript.currentStep] >= objectToCraftScript.steps.Length) && (gameObject.tag != "Stash"))
            {
                objectToCraftScript.DestroyThisObject();
                //put object to Stash
                if(gameObject.tag == "Stash")
                {
                    Debug.Log("Put Object To Stash");
                    gameObject.GetComponent<Stash_Inventory>().AddItemToStash(currentObjectToForge);
                }
            }
            else
            {
                //corriger ici car on compare un index avec une valeur
                if(objectToCraftScript.steps[objectToCraftScript.currentStep +1 ] == step)
                {
                objectToCraftScript.GoNextStep();
                }
                else
                {
                    Debug.Log("je vais detruire cet objet");
                    objectToCraftScript.DestroyThisObject();
                }
            }*/
        }

        //Ici les restrictions par object
        if(gameObject.tag == "Cart")
        {
            if (currentObjectToForge == null)
            {
                Instantiate(doGoto.objectToForgePrefab,doGoto.objectToForgeSlot.transform);
                currentObjectToForge = doGoto.objectToForgePrefab;
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
        }

        if(gameObject.tag == "Pannel")
        { 
        } 

        if(gameObject.tag == "Horse")
        {  
        }
        if(gameObject.tag == "Thief")
        {  
        }
    }
}