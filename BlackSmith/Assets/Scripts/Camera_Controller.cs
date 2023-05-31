using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
// for finger
public float scrollSpeed = 1f;

//for mouse
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
 
    public bool cameraDragging = true;
 
    //Level Sizing
    public enum LevelSize{ Little, Middle, Big }
    public LevelSize levelSize;
    public float outerLeft = -11f;
    public float outerRight = 11f;
    public GameObject BackGroundBig;
    public GameObject MiddleGroundBig;
    public GameObject BackGroundMiddle;
    public GameObject MiddleGroundMiddle;
    public GameObject BackGroundLittle;
    public GameObject MiddleGroundLittle;

    //floowThePlayerAtTheBegginning
    public Transform target;
    public float smoothing;
    Vector3 offset;
    public float lowY;
    public bool cameraCanScroll = false;
    public bool cameraCanFollow = false;
    Camera cam;
 
    void Start()
    {
        offset = transform.position;
        cameraCanFollow = true;
        cam = GetComponent<Camera>();

        ResizeLevel();
        //Debug.Log(Application.platform);
    }

    void Update()
    {       
        //CameraFollowPlayer
        if(cameraCanFollow)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);
            if (transform.position.y < lowY) 
            {
                transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
            }
            
            if(Mathf.Round(transform.position.x*100)/100 == Mathf.Round(targetCamPos.x*100)/100)
            {
                cameraCanFollow = false;
                cameraCanScroll = true;

            }
        }
        
        //CameraScroll
//for mobile
     #if UNITY_EDITOR
             //Debug.Log("Editor");
        if(cameraCanScroll)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
         
            float left = Screen.width * 0.2f;
            float right = Screen.width - (Screen.width * 0.2f);
         
            if(mousePosition.x < left)
            {
                cameraDragging = true;
            }
            else if(mousePosition.x > right)
            {
                cameraDragging = true;
            }
            if (cameraDragging) 
            {
             
                if (Input.GetMouseButtonDown(0))
                {
                    dragOrigin = Input.mousePosition;
                    return;
                }
             
                if (!Input.GetMouseButton(0)) 
                {
                    return;
                }
             
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);
             
                if (move.x < 0f)
                {
                    if(this.transform.position.x < outerRight)
                    {
                        transform.Translate(-move, Space.World);
                    }
                }
                else{
                    if(this.transform.position.x > outerLeft)
                    {
                        transform.Translate(-move, Space.World);
                    }
                		}
            }

        }
        #elif UNITY_ANDROID
            //Debug.Log("Android");
		if(cameraCanScroll)
        {
            if (Input.touchCount > 0)
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Moved)
                    {
                        float scrollDelta = touch.deltaPosition.x * scrollSpeed * Time.deltaTime;
                        transform.position -= new Vector3(scrollDelta, 0f, 0f);
                    }
                }
        }
     #elif UNITY_IOS 
             //Debug.Log("Ios");
     #elif UNITY_STANDALONE_OSX
             //Debug.Log("Osx");
     #elif UNITY_STANDALONE_WIN
             //Debug.Log("Win");
     #endif



//for mouse

    }

    public void AlignCameraToPlayer()
    {
        //Debug.Log("Je m'aligne");
        Vector3 targetCamPos = target.position + offset;
        //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);
        cameraCanFollow = true;
        cameraCanScroll = false;

        //Debug.Log(Mathf.Round(transform.position.x*100)/100 +"__"+ Mathf.Round(targetCamPos.x*100)/100);
    }
 
    void ResizeLevel()
    {
        if(levelSize == LevelSize.Big)
        {
            BackGroundBig.SetActive(true);
            MiddleGroundBig.SetActive(true);
            BackGroundMiddle.SetActive(false);
            MiddleGroundMiddle.SetActive(false);
            BackGroundLittle.SetActive(false);
            MiddleGroundLittle.SetActive(false);
            outerLeft = -50f;
            outerRight = 50f;
        }

        if(levelSize == LevelSize.Middle)
        {
            BackGroundBig.SetActive(false);
            MiddleGroundBig.SetActive(false);
            BackGroundMiddle.SetActive(true);
            MiddleGroundMiddle.SetActive(true);
            BackGroundLittle.SetActive(false);
            MiddleGroundLittle.SetActive(false);
            outerLeft = -30f;
            outerRight = 30f;
        }

        if(levelSize == LevelSize.Little)
        {
            BackGroundBig.SetActive(false);
            MiddleGroundBig.SetActive(false);
            BackGroundMiddle.SetActive(false);
            MiddleGroundMiddle.SetActive(false);
            BackGroundLittle.SetActive(true);
            MiddleGroundLittle.SetActive(true);
            outerLeft = -11f;
            outerRight = 11f;
        }
           
    }

}