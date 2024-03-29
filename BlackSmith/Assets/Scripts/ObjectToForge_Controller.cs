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
    public int goldGranted;
    //private bool isFinished;
/*    public bool doDestroyObject;*/
    public GameObject iconInStack;
    Animator myAnim;
    public GameObject stash;

    // Start is called before the first frame update
    void Start()
    {
        //stash = GameObject.Find("Interactible_Stash");
        stash = GameObject.FindWithTag("Stash");
        myAnim = GetComponent<Animator>();
        //doDestroyObject = false;
        //isFinished = false;
        currentStep = 0;
        currentStepValue = 0;
        objectStepMax = steps.Length;
        //set the first sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[0]; 
        //Debug.Log("Dernier Step: "+steps[steps.Length-1]);
        GameManager.instance.stepToGo = steps[1];

    }

    // Update is called once per frame
    void Update()
    {
/*        if(doDestroyObject == true)
        Destroy(gameObject);*/
        //Debug.Log(steps.Length);

    }

    public void GoNextStep(int stepValueOfObject)
    {
        currentStep ++;
        if(currentStep < steps.Length-1)
        {
            GameManager.instance.stepToGo = steps[currentStep+1];
        }
        //Debug.Log("Dernier Step: "+steps[steps.Length-1]+", step cliqué: "+ stepValueOfObject+", step que je suis sencé avoir: "+steps[currentStep]);
        

        if(stepValueOfObject == steps[currentStep])
        {
                if(steps[steps.Length-1] ==stepValueOfObject)
                {
                    GameManager.instance.UpdateGold(+goldGranted);
                    DestroyThisObject();
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[currentStep];
                }
        }
        else
        {
            DestroyThisObject();
        }
/*        {
            Stash_Inventory stashScript = stash.gameObject.GetComponent<Stash_Inventory>();
            stashScript.AddItemToStash(gameObject);
            GameManager.instance.UpdateGold(+goldGranted);
            DestroyThisObject();
        }
        else if (currentStep < steps.Length)
        {
            currentStep ++;
            currentStepValue = steps[currentStep];
            gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[currentStep];
        }
        else if (currentStepValue == steps[steps.Length])
        {
            Debug.Log("j'ai fini");
        }
        else
        {
            DestroyThisObject();
        }
        Debug.Log("currentStep : "+currentStep +" | steps.Value : "+ steps[currentStep] +" | steps.Length : "+ steps.Length);
 */   }

    public void DestroyThisObject()
    {
        //failAnim.SetActive(true);
        //Debug.Log("Object Détruit");
        GameManager.instance.stepToGo = 0;
        myAnim.SetTrigger("toDestroy");
        Destroy(gameObject);
    }
}
