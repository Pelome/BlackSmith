using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ_Controller : MonoBehaviour
{
    //QuestsVariables
    bool isVoleur;
    bool isChevalier;
    bool pnjLevel;
    
    //movement variables
    public float speed = 0.005f;

    //jumping variables   
    public bool isCheering = false;
    public bool isQuestPosing = false;
    public bool isMoving = false;
    public bool isGrogning = false;
    public bool isDoitSortir = false; // peut etre inutile
    
    Rigidbody2D myRB;
    Animator myAnim;
    AudioSource playerAS;
    public bool facingRight;
    public bool canMove = true; // peut etre inutile

    //for shooting
    public Transform questTip;
    public Transform awardTip;
    public GameObject QuestPosingEffect;
    public GameObject CheerAward;
    public GameObject destPosition; // peut etre private
    public GameObject panelPosition; // peut etre private
    public GameObject exitPosition; // peut etre private
    public Transform initialPosition;
    public AudioClip questPosingSound;
    public AudioClip CheeringSound;
    private SpriteRenderer objectQuestSprite; // a faire pour que le pnj apporte la lettre dans la main
    GameObject questObject; // peut etre inutile
    public float Timer = 2;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();
        facingRight = true;
        panelPosition = GameObject.FindWithTag("QuestPannel");
        exitPosition = GameObject.FindWithTag("PorteChateau");
        destPosition = panelPosition;
        GoToPanel();
    }   

    void Update()
    {   
        myAnim.SetBool("isMoving",isMoving);
        //myAnim.SetBool("isQuestPosing", isQuestPosing);
       // myAnim.SetBool("isCheering", isCheering);
        //myAnim.SetBool("isGrogning", isGrogning);           
    }

    public void GoToPanel()
    {
         if (!isMoving && canMove)// peut etre inutile
         {
            if(destPosition.transform.position.x > initialPosition.transform.position.x && facingRight)
            {
                flip();
            }
            if(destPosition.transform.position.x < initialPosition.transform.position.x && !facingRight)
            {
                flip();
            }
            playerAS.Stop();
            StartCoroutine (goTo(destPosition));
         }
    }
    
    public void GoToExit()
    {
        if (!isMoving && canMove)// peut etre inutile
        {
            destPosition = exitPosition;
            if(destPosition.transform.position.x > initialPosition.transform.position.x && facingRight)
            {
                flip();
            }
            if(destPosition.transform.position.x < initialPosition.transform.position.x && !facingRight)
            {
                flip();
            }
            playerAS.Stop();
            StartCoroutine (doGoToExit(destPosition));
         }
    }
        
    IEnumerator goTo(GameObject destPosition)
    {
            yield return new WaitForSeconds(.01f);  
            while (initialPosition.transform.position.x != destPosition.transform.position.x)
            {
                initialPosition.transform.position = Vector3.MoveTowards(new Vector2(initialPosition.transform.position.x,initialPosition.transform.position.y), new Vector2(destPosition.transform.position.x,initialPosition.transform.position.y), speed*Time.deltaTime);
                isMoving = true;
                yield return new WaitForEndOfFrame();
            }
            isMoving = false;
    }

    IEnumerator doGoToExit(GameObject destPosition)
    {
            yield return new WaitForSeconds(.01f);
            while (initialPosition.transform.position.x != destPosition.transform.position.x)
            {
                initialPosition.transform.position = Vector3.MoveTowards(new Vector2(initialPosition.transform.position.x,initialPosition.transform.position.y), new Vector2(destPosition.transform.position.x,initialPosition.transform.position.y), speed*Time.deltaTime);
                isMoving = true;
                yield return new WaitForEndOfFrame();
            }
            isMoving = false;
    }

    void playQuestPosing()
    {
        if(!isMoving)
        {
            Instantiate(QuestPosingEffect, questTip.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            playerAS.PlayOneShot(questPosingSound);
        }
    }
    
    void playCheering()
    {
        if(!isMoving)
        {
            Instantiate(CheerAward, awardTip.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            playerAS.PlayOneShot(CheeringSound);
        }
    }

    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}