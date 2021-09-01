using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToForge_Controller : MonoBehaviour
{

    public Sprite[] objectSprites;
    public int objectID;
    public string objectName;
    public int objectStepMax;

    // Start is called before the first frame update
    void Start()
    {
        //set the first sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = objectSprites[1]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
