using PixelPlay.OffScreenIndicator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class OffScreenIndicator2 : MonoBehaviour
{
    [Range(0.5f, 0.9f)]
    [Tooltip("Distance offset of the indicators from the centre of the screen")]
    [SerializeField] private float screenBoundOffset = 0.9f;

    private Camera mainCamera;
    private Vector3 screenCentre;
    private Vector3 screenBounds;

    private List<Target2> targets = new List<Target2>();

    public static Action<Target2, bool> TargetStateChanged;

    void Awake()
    {
        mainCamera = Camera.main;
        screenCentre = new Vector3(Screen.width, Screen.height, 0) / 2;
        screenBounds = screenCentre * screenBoundOffset;
        TargetStateChanged += HandleTargetStateChanged;
    }

    void LateUpdate()
    {
        DrawIndicators();
    }

    // Draw the indicators on the screen and set thier position and rotation and other properties.
    void DrawIndicators()
    {
        foreach(Target2 target2 in targets)
        {
            Vector3 screenPosition = OffScreenIndicatorCore.GetScreenPosition(mainCamera, target2.transform.position);
            bool isTargetVisible = OffScreenIndicatorCore.IsTargetVisible(screenPosition);
            Indicator indicator = null;

            if(target2.NeedArrowIndicator && !isTargetVisible)
            {
                float angle = float.MinValue;
                OffScreenIndicatorCore.GetArrowIndicatorPositionAndAngle(ref screenPosition, ref angle, screenCentre, screenBounds);
                indicator = GetIndicator(ref target2.indicator, IndicatorType.ARROW); // Gets the arrow indicator from the pool.
            }
            else
            {
                target2.indicator?.Activate(false);
                target2.indicator = null;
            }
            if(indicator)
            {
                indicator.transform.position = screenPosition; //Sets the position of the indicator on the screen.
            }
        }
    }

    private void HandleTargetStateChanged(Target2 target2, bool active)
    {
        if(active)
        {
            targets.Add(target2);
        }
        else
        {
            target2.indicator?.Activate(false);
            target2.indicator = null;
            targets.Remove(target2);
        }
    }

    private Indicator GetIndicator(ref Indicator indicator, IndicatorType type)
    {
        if(indicator != null)
        {
            if(indicator.Type != type)
            {
                indicator.Activate(false);
                indicator = ArrowObjectPool2.current.GetPooledObject();
                indicator.Activate(true); // Sets the indicator as active.
            }
        }
        else
        {
            indicator = ArrowObjectPool2.current.GetPooledObject();
            indicator.Activate(true); // Sets the indicator as active.
        }
        return indicator;
    }

    private void OnDestroy()
    {
        TargetStateChanged -= HandleTargetStateChanged;
    }
}
