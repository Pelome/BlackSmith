//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Indicator : MonoBehaviour
{
    [SerializeField] private IndicatorType indicatorType;
    private Image indicatorImage;
    public GameObject levelCam;

    // Gets if the game object is active in hierarchy.
    public bool Active
    {
        get
        {
            return transform.gameObject.activeInHierarchy;
        }
    }

    // Gets the indicator type
    public IndicatorType Type
    {
        get
        {
            return indicatorType;
        }
    }

    void Awake()
    {
        indicatorImage = transform.GetComponent<Image>();

    }
/*    void Start()
    {
        levelCam = GameObject.Find("Main Camera");
        CameraController cameraScript = levelCam.gameObject.GetComponent<CameraController>();

    }*/

    // Sets the indicator as active or inactive.
    public void Activate(bool value)
    {
        transform.gameObject.SetActive(value);
    }

    public void buttonToAlign()
    {
        Debug.Log("realignemoi");
        levelCam = GameObject.Find("Main Camera");
        Camera_Controller cameraScript = levelCam.gameObject.GetComponent<Camera_Controller>();
        cameraScript.AlignCameraToPlayer();
    }


}

public enum IndicatorType
{
    ARROW
}
