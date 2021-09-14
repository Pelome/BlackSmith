using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public bool isMoving = false;
    public bool canMove = true;
    public bool isAtDestination = false;
    public bool facingRight;
    public Transform initialPosition;
    //public bool isTaskFinished = false;
    //public float taskProgressMax = 100;
   // public float taskProgress = 0;
    //public Slider progressTaskSlider;
    Animator myAnim;
    //Audio
    AudioSource playerAS;
    public AudioClip forgeHitSound;
    public AudioClip smokeSound;
    public AudioClip ferrierSound;
    public AudioClip forgingSound;
    public GameObject objectToForgePrefab;
    public GameObject objectToForgeSlot;
    public Transform target;
    public GameObject objectToReach;

    void Start()
    {
        playerAS = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        myAnim.SetBool("isMoving",isMoving);
        if(target != null)
        {
            isMoving = true;
            // Move Our Position a step closet to the current Target
            float step  = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            //check if arrived at position
            if (Vector3.Distance(transform.position, target.position)< 0.001f)
            {
                if(target != null)
                {
                    if(facingRight == true )
                    {
                        flip();
                    }
                    objectToReach.GetComponent<OnClickOnObjectGoto>().IamAtDestination();
                    target = null;
                    isMoving = false;
                }
            }
        }
    }

    public void isClickeed(Transform destPosition, GameObject destinationObject)
    {
        target = destPosition;
        objectToReach = destinationObject;
        if (!isMoving && canMove)
        {

            if(destPosition.transform.position.x < initialPosition.transform.position.x && facingRight)
            {
                flip();
            }
            if(destPosition.transform.position.x > initialPosition.transform.position.x && !facingRight)
            {
                flip();
            }
            //isTaskFinished = false;
            //taskProgress = 0;
            //progressTaskSlider.gameObject.SetActive(false);
            //playerAS.Stop();
        }
    }

    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
       // Vector3 sliderScale = progressTaskSlider.transform.localScale;
        //sliderScale.x *= -1;
        //progressTaskSlider.transform.localScale = sliderScale;
    }
}
