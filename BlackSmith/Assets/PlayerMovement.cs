using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public bool isMoving = false;
    public bool canMove = true;
    public bool facingRight;
    public Transform initialPosition;
    public bool isTaskFinished = false;
    //public float taskProgressMax = 100;
   // public float taskProgress = 0;
    //public Slider progressTaskSlider;
    Animator myAnim;
    AudioSource playerAS;

    // Start is called before the first frame update
    void Start()
    {
        playerAS = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("isMoving",isMoving);

/*        float step = speed * Time.deltaTime;

        //if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x,0,0), step);*/
    }

    public void isClickeed(Transform destPosition)
    {
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
            
            isTaskFinished = false;
            //taskProgress = 0;
            //progressTaskSlider.gameObject.SetActive(false);
            //playerAS.Stop();
            StartCoroutine (goTo(destPosition));
        }
    }
        
    IEnumerator goTo(Transform destPosition)
    {
            yield return new WaitForSeconds(.01f);
            
            while (initialPosition.transform.position.x != destPosition.position.x)
            {
            initialPosition.transform.position = Vector3.MoveTowards(new Vector2(initialPosition.transform.position.x,initialPosition.transform.position.y), new Vector2(destPosition.position.x,initialPosition.transform.position.y), speed);
            isMoving = true;

            yield return new WaitForEndOfFrame();
            }
            isMoving = false;
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
