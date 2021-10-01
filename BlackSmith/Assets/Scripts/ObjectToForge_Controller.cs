using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToForge_Controller : MonoBehaviour
{
    public Sprite[] objectSprites;
    public int objectID;
    public string objectName;
    public int objectStepMax;
    public int[] steps;
    public int currentStep;
    public int currentStepValue;
    //private bool isFinished;
    public bool doDestroyObject;
    public GameObject iconInStack;
    Animator myAnim;
    public GameObject stash;

    // Start is called before the first frame update
    void Start()
    {
        stash = GameObject.Find("Interactible_Stash");
        myAnim = GetComponent<Animator>();
        doDestroyObject = false;
        //isFinished = false;
        currentStep = 0;
        currentStepValue = 0;
        objectStepMax = steps.Length;
        //set the first sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        if(doDestroyObject == true)
        Destroy(gameObject);
    }

    public void GoNextStep()
    {
        if(currentStep == steps.Length -1)
        {
            Stash_Inventory stashScript = stash.gameObject.GetComponent<Stash_Inventory>();
            stashScript.AddItemToStash(gameObject);
            DestroyThisObject();
        }
        if (currentStep < steps.Length)
        {
            currentStep ++;
            currentStepValue = steps[currentStep];
            gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[currentStep];
        }
        else
        {
            DestroyThisObject();
        }
        Debug.Log("currentStep : "+currentStep +" | steps.Value : "+ steps[currentStep] +" | steps.Length : "+ steps.Length);
    }

    public void DestroyThisObject()
    {
        //failAnim.SetActive(true);
        Debug.Log("Object Détruit");
        myAnim.SetTrigger("toDestroy");
    }
}
