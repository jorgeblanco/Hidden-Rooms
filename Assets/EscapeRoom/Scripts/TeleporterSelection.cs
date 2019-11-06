using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class TeleporterSelection : BooleanAction
{
    public OVRInput.Controller controller = OVRInput.Controller.Active;
    public FloatAction extractX;
    public FloatAction extractY;

    private bool _ignoreTouch;
    
    protected OVRInput.Touch touch = OVRInput.Touch.PrimaryThumbstick;
    protected OVRInput.Axis2D axis = OVRInput.Axis2D.PrimaryThumbstick;
    protected bool wasThumbstickTouched = false;
    protected Vector2 lastThumbstickPos = new Vector2(0, 1);

    private void Start()
    {
#if UNITY_EDITOR
        _ignoreTouch = true;
#endif
    }

    void Update() {
        bool isTumbstickTouched = OVRInput.Get(touch, controller);

        Vector2 currentThumbstickPos = OVRInput.Get(axis, controller).normalized;
        if ((!isTumbstickTouched && !_ignoreTouch) || currentThumbstickPos.sqrMagnitude < 0.5f * 0.5f) {
            currentThumbstickPos = lastThumbstickPos;
        }
        else
        {
            isTumbstickTouched = true;
        }

        Receive(!isTumbstickTouched && wasThumbstickTouched);

        wasThumbstickTouched = isTumbstickTouched;
        lastThumbstickPos = currentThumbstickPos;

        if (extractX != null) {
            extractX.Receive(currentThumbstickPos.x);
        }
        if (extractY != null) {
            extractY.Receive(currentThumbstickPos.y);
        }
    }
}
