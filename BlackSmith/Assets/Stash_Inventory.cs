using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stash_Inventory : MonoBehaviour
{
    public GameObject[] slotsPos;
    public GameObject[] slots;
    public int positionToAdd;

// for testing
    public GameObject itemToAdd;
    public Sprite transparentSprite;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0 ; i < slotsPos.Length; i++)
        {
            slots[i] = null;
            
        slotsPos[i].GetComponent<Image>().sprite = transparentSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToStash(/*GameObject itemToAdd*/)
    {
        for (int i =0 ; i < slotsPos.Length; i++)
        {
            if(slots[i] == null)
            {
                positionToAdd = i;
                slots[positionToAdd] = itemToAdd;
                slotsPos[positionToAdd].GetComponent<Image>().sprite = itemToAdd.GetComponent<SpriteRenderer>().sprite;
                return;
            }
        }
    }


//gerer ce cas si le stack est complet, il faut remonter une erreur et une indication, l'objet doit etre détruit


    public void ChooseRandomItemInStack()
    {
        //choisir un item en vrac
    }

    public void DeleteItemToStack()
    {

        //sortir un item du sac
    }
}
