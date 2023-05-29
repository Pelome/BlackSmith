using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_Arrow : MonoBehaviour
{

    public float speed = 0.2f;
    public Transform target;
    //public float ecartValue = 0.1f; 
    public Transform point1;
    public Transform point2;
    public int Step;
    // Start is called before the first frame update
    void Start()
    {
        target = point1;
        //point1 = gameObject.transform;
        //point2 = gameObject.transform;
        //point1.position.y = gameObject.transform.position.y - 0.1f;
        //point2.position.y = gameObject.transform.position.y + 0.1f;

        //target.transform.position = gameObject.transform.position.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (200*Time.deltaTime,0,0); //rotates 50 degrees per second around z axis
        float step  = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if(GameManager.instance.stepToGo == Step)
        {   
            //green
            Color newColor = new Color(0f, 1f, 0f, 1f);
            GetComponent<SpriteRenderer>().color = newColor;
        }
        else
        {
            if ( Step == (100))
            {
                //Do Not change the arrow Color
            }
            else
            {
            Color newColor = new Color(1f, 1f, 1f, 1f);
            GetComponent<SpriteRenderer>().color = newColor;
            }
        }

        //check if arrived at position
        if (Vector3.Distance(transform.position, target.position)< 0.001f)
        {
            //Vector3 p = new Vector3(gameObject.transform.position.x,ecartValue,gameObject.transform.position.z);
            //target.position = p;
            //ecartValue = -ecartValue;
            if (target == point1)
            {
                target = point2;
            }
            else
            {
                target = point1;
            }
        }
    }
}
