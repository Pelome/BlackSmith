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
    //public GameObject failAnim;
    public bool doDestroyObject;
    public GameObject iconInStack;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        doDestroyObject = false;
        //isFinished = false;
        currentStep = 0;
        currentStepValue = 0;
        objectStepMax = steps.Length;
        //failAnim.SetActive(false);
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
    }

    public void DestroyThisObject()
    {
        //failAnim.SetActive(true);
        myAnim.SetTrigger("toDestroy");

    }
}
