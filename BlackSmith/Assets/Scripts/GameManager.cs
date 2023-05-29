using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] objectsInStash;
    public int goldInStash;
    public int staminaInStash;
    public int dollarInStash;
    public int experienceInStash;
    public int stepToGo;

    //objectToCraft
    public GameObject objectToCraft;
    private int objectToCraftID;
    private string objectToCraftName;
    private int objectCraftStepMax;
    private int objectCraftStep;

    public FloatingTextManager floatingTextManager;


    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            //Destroy(player.gameObject);
            //Destroy(floatingTextManager.gameObject);
            //Destroy(hud);
            //Destroy(menu);
            return;
        }
 
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        stepToGo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //GetObjectToCraftScript
        //this have to be passed outside update but later in a future function OnObjectChange()
        ObjectToForge_Controller objectToCraftScript = objectToCraft.gameObject.GetComponent<ObjectToForge_Controller>();
        
        objectToCraftID = objectToCraftScript.objectID;
        objectToCraftName = objectToCraftScript.objectName;
        objectCraftStepMax = objectToCraftScript.objectStepMax;
    }

    public void SetGold(int newValue)
    {
        goldInStash = newValue;
    }

    public void UpdateGold(int newValue)
    {
        goldInStash = goldInStash+newValue;
        if (goldInStash <=0)
        {
            dollarInStash = 0;
        }
    }

    //FloatingText
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public int GetCurrentGold()
    {
        return goldInStash;
    }
    public int GetCurrentStamina()
    {
        return staminaInStash;
    }
    public int GetCurrentDollar()
    {
        return dollarInStash;
    }
    public int GetCurrentExperience()
    {
        return experienceInStash;
    }
    public int GetCurrentStep()
    {
        return stepToGo;
    }


    //prendre objet a crafter
    public void TakeObjectToCraft()
    {

    }

    //casser objet a crafter en cas d'echec
    public void DestroyObjectToCraft()
    {

    }

    //poser objet crafté
    public void DropObjectToCraft()
    {

    }


}
