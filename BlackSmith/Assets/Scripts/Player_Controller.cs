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
    private Animator myAnim;
	private Rigidbody2D myRB;
    //Audio
    AudioSource playerAS;
    public AudioClip forgeHitSound;
    public AudioClip smokeSound;
    public AudioClip ferrierSound;
    public AudioClip forgingSound;
    public AudioClip grindingSound; 
    public GameObject objectToForgePrefab;
    public GameObject objectToForgeSlot;
    public Transform target;
    public GameObject objectToReach;

    void Start()
    {
        playerAS = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myAnim.SetBool("isMoving",isMoving);
        if(target != null)
        {
            isMoving = true;
            // Move Our Position a step closer to the current Target
            //float step  = speed * Time.fixedDeltaTime; // calculate distance to move
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Vector2 currentPosition = myRB.position;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, target.position, speed * Time.fixedDeltaTime);
            myRB.MovePosition(newPosition);

            //check if arrived at position
            if (Vector3.Distance(transform.position, target.position)< 0.001f)
            {
                Debug.Log("JesuisArrivé");
                if(target != null)
                {
                    if(facingRight == true )
                    {
                        flip();
                    }
                    objectToReach.GetComponent<OnClickOnObjectGoto>().IamAtDestination();
                    target = null;
                    isMoving = false;
                    if (objectToReach.tag == "Anvil")
                    {
                        Debug.Log("Je suis a anvil");
                        //trouver ici le systeme pour donner le ton par défaut.
                        playerAS.clip = forgeHitSound;
                        myAnim.SetTrigger("Anvil");
                    }
                    if (objectToReach.tag == "Barrel")
                    {
                        Debug.Log("Je suis a Barrel");
                        playerAS.clip = smokeSound;
                        myAnim.SetTrigger("Barrel");
                    }
                    if (objectToReach.tag == "Horse")
                    {
                        Debug.Log("Je suis a Horse");
                        playerAS.clip = ferrierSound;
                        myAnim.SetTrigger("Horse");
                    }
                    if (objectToReach.tag == "Thief")
                    {
                        Debug.Log("Je suis a Thief");
                        playerAS.clip = ferrierSound;
                        myAnim.SetTrigger("Thief");
                    }
                    if (objectToReach.tag == "FireBowl")
                    {
                        Debug.Log("Je suis a FireBowl");
                        //playerAS.clip = forgingSound;
                        myAnim.SetTrigger("FireBowl");
                    }
                    if (objectToReach.tag == "Meule")
                    {
                        Debug.Log("Je suis a Meule");
                        playerAS.clip = grindingSound;
                        myAnim.SetTrigger("Meule");
                    }
                    if (objectToReach.tag == "Pannel")
                    {
                        Debug.Log("Je suis a Pannel");
                        //playerAS.clip = forgingSound;
                        //myAnim.SetTrigger("FireBowl");
                    }
                    if (objectToReach.tag == "Stash")
                    {
                        Debug.Log("Je suis a Stash");
                        //playerAS.clip = forgingSound;
                        //myAnim.SetTrigger("FireBowl");
                    }
                }
            }
        }
    }

    public void isClickeed(Transform destPosition, GameObject destinationObject)
    {
        //a quoçi sert ce script a part le flip, c'est dans l'update que se fait le mouvement tout le temps, ici se regle la variable target
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
