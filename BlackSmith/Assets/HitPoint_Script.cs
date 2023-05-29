using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D other)
{
if(other.tag == "Thief")
{
Debug.Log("PanPan");
other.GetComponent<PNJ_Controller>().RecieveDamage();
}
}
}
