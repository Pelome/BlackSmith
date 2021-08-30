using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControler : MonoBehaviour
   {
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
 
    public bool cameraDragging = true;
 
    public float outerLeft = -10f;
    public float outerRight = 10f;
    
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
             
                if (move.x > 0f)
                {
                    if(this.transform.position.x < outerRight)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
                else{
                    if(this.transform.position.x > outerLeft)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
            }
        }
    }

    public void AlignCameraToPlayer()
    {
        Debug.Log("Je m'aligne");
        Vector3 targetCamPos = target.position + offset;
        //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);
        cameraCanFollow = true;
        cameraCanScroll = false;

        Debug.Log(Mathf.Round(transform.position.x*100)/100 +"__"+ Mathf.Round(targetCamPos.x*100)/100);
    }
 
 
}