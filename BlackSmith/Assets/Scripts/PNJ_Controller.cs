using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJ_Controller : MonoBehaviour
{
    //QuestsVariables
    bool isVoleur;
    bool isChevalier;
    bool pnjLevel;
    
    //movement variables
    public float speed = 0.005f;
    private int goldToSteal;
    public Sprite goldSprite;

    //jumping variables   
    public bool isCheering = false;
    public bool isQuestPosing = false;
    public bool isMoving = false;
    public bool isFleeing= false;
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
    public GameObject spawnTextPosition;
    public GameObject spriteToFlip;
    public GameObject QuestPosingEffect;
    public GameObject CheerAward;
    public GameObject destPosition; // peut etre private
    public GameObject panelPosition; // peut etre private
    public GameObject stashPosition; // peut etre private
    public GameObject exitPosition; // peut etre private
    public GameObject castleDoorPosition; // peut etre private
    public Transform initialPosition;
    public AudioClip questPosingSound;
    public AudioClip CheeringSound;
    private SpriteRenderer objectQuestSprite; // a faire pour que le pnj apporte la lettre dans la main
    GameObject questObject; // peut etre inutile
    public float Timer = 2;
    
    void Start()
    {
        goldToSteal = 0;
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponentInChildren<Animator>();
        playerAS = GetComponent<AudioSource>();
        facingRight = true;
        panelPosition = GameObject.FindWithTag("QuestPannel");
        stashPosition = GameObject.FindWithTag("Stash");
        castleDoorPosition = GameObject.FindWithTag("PorteChateau");
        exitPosition = GameObject.FindWithTag("ExitPoint");    
        
        if (gameObject.tag == "Page")
        {
            destPosition = panelPosition;
        }

        if (gameObject.tag == "Thief")
        {
            destPosition = stashPosition;
        }

        GoToGoal();
    }   

    void Update()
    {   
        myAnim.SetBool("isMoving",isMoving);
        myAnim.SetBool("isFleeing",isFleeing);
        //myAnim.SetBool("isQuestPosing", isQuestPosing);
       // myAnim.SetBool("isCheering", isCheering);
        //myAnim.SetBool("isGrogning", isGrogning);           
    }
    public void Stop()
    {
        isMoving = false;
        StopAllCoroutines();
    }

    public void GoToGoal()
    {
         if (!isMoving && canMove)// peut etre inutile
         {
            Debug.Log("J'y vais");
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
            Debug.Log("je fuis");
            destPosition = exitPosition;
            if(destPosition.transform.position.x > initialPosition.transform.position.x && facingRight)
            {
                Debug.Log("Je flip");
                flip();
            }
            if(destPosition.transform.position.x < initialPosition.transform.position.x && !facingRight)
            {
                Debug.Log("Je flip");

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
            //VOler de l'or dans le coffre
            if((initialPosition.transform.position.x == destPosition.transform.position.x)&&(gameObject.tag == "Thief")&&(destPosition == stashPosition))
            {
                StealingGold();
            }
            isMoving = false;
    }

    IEnumerator doGoToExit(GameObject destPosition)
    {
            //destPosition = exitPosition;
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

    void StealingGold()
    {
        Debug.Log("Le voleur est au coffre");
        // je vole 10% a chaque fois
        int goldInStash = GameManager.instance.GetCurrentGold();
        
        if(goldInStash <= 10)
        {
            goldToSteal = 1;
            if(goldInStash <= 0)
            {
               goldToSteal = 0;
            }
        }
        else
        {
            goldToSteal = (int)(goldInStash * 0.1f);  
        }

        Debug.Log(goldToSteal);
        GameManager.instance.UpdateGold(-goldToSteal);
        spawnTextPosition.GetComponent<SpriteRenderer>().sprite = goldSprite;
        //couleur du popup de texte
        Color newColor = new Color(1f, 0.92f, 0.016f, 1f);
        Vector3 newVector = new Vector3(Random.Range(-40f,40f),100,0);
        //faire spawner le popup de texte
        GameManager.instance.ShowText("Volé: "+(goldToSteal).ToString(),48,newColor,spawnTextPosition.transform.position,newVector,1.5f);
        StartCoroutine (MakeFlee());
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
        Vector3 theScale = spriteToFlip.transform.localScale;
        theScale.x *= -1;
        spriteToFlip.transform.localScale = theScale;
    }

    public void RecieveDamage()
    {
        Stop();
        myAnim.SetTrigger("Hurt");
        spawnTextPosition.GetComponent<SpriteRenderer>().sprite = null;
        GameManager.instance.UpdateGold(+goldToSteal);
        Color newColor = new Color(1f, 0.92f, 0.016f, 1f);
        Vector3 newVector = new Vector3(Random.Range(-40f,40f),100,0);
        //faire spawner le popup de texte
        if(goldToSteal != 0)
        {
            GameManager.instance.ShowText("Récupéré: "+(goldToSteal).ToString(),48,newColor,spawnTextPosition.transform.position,newVector,1.5f);
        }
        goldToSteal =  0;

        StartCoroutine (MakeFlee());

    }

    IEnumerator MakeFlee()
    {
        yield return new WaitForSeconds(.2f);
        isFleeing = true;
        //destPosition = exitPosition;
        speed = 1;
        GoToExit();
    }


}