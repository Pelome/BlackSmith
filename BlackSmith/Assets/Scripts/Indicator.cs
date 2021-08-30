using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    [SerializeField] private IndicatorType indicatorType;
    private Image indicatorImage;


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

    // Sets the indicator as active or inactive.
    public void Activate(bool value)
    {
        transform.gameObject.SetActive(value);
    }
}

public enum IndicatorType
{
    ARROW
}
