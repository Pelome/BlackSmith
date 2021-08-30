using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] objectsInStash;
    public int goldInStash;

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
}
