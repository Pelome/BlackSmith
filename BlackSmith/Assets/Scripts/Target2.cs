using UnityEngine;

[DefaultExecutionOrder(0)]
public class Target2 : MonoBehaviour
{
    [Tooltip("Select if arrow indicator is required for this target")]
    [SerializeField] private bool needArrowIndicator = true;

     public Indicator indicator;

    // Gets if arrow indicator is required for the target.
    public bool NeedArrowIndicator
    {
        get
        {
            return needArrowIndicator;
        }
    }

    public void AbleNeedArrowIndicator(bool isneeded)
    {
    	needArrowIndicator = isneeded;
    }

    // On enable add this target object to the targets list.
    private void OnEnable()
    {
        if(OffScreenIndicator2.TargetStateChanged != null)
        {
            OffScreenIndicator2.TargetStateChanged.Invoke(this, true);
        }
    }

    // On disable remove this target object from the targets list.
    private void OnDisable()
    {
        if(OffScreenIndicator2.TargetStateChanged != null)
        {
            OffScreenIndicator2.TargetStateChanged.Invoke(this, false);
        }
    }

    // Gets the distance between the camera and the target.
    public float GetDistanceFromCamera(Vector3 cameraPosition)
    {
        float distanceFromCamera = Vector3.Distance(cameraPosition, transform.position);
        return distanceFromCamera;
    }
}
