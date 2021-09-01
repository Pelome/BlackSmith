using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] objectsInStash;
    public int goldInStash;

    //objectToCraft
    public GameObject objectToCraft;
    private int objectToCraftID;
    private string objectToCraftName;
    private int objectCraftStepMax;
    private int objectCraftStep;


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

    public int GetCurrentGold()
    {
/*        int r = 0;
        int add = 0;

        while(experience >= add)
        {
            add += xpTable[r];
            r++;

            if(r == xpTable.Count) // if max level
            return r;
        }
*/
        return goldInStash;
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
