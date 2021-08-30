using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractibleObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            GameObject.Find("Canvas").SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            GameObject.Find("Canvas").SetActive(false);
        }
    }
}