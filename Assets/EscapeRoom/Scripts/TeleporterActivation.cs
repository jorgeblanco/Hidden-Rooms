using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class TeleporterActivation : BooleanAction
{
    public OVRInput.Controller controller = OVRInput.Controller.Active;

    private bool _ignoreTouch;

    protected OVRInput.Touch touch = OVRInput.Touch.PrimaryThumbstick;
    protected OVRInput.Axis2D axis = OVRInput.Axis2D.PrimaryThumbstick;
    protected float thumbstickDistanceSq = 0.75f * 0.75f;
    protected bool validLastFrame = false;
    protected bool validTwoFramesAgo = false;

    private void Start()
    {
#if UNITY_EDITOR
        _ignoreTouch = true;
#endif
    }
    
    void Update() {
        bool isTumbstickTouched = OVRInput.Get(touch, controller);
        Vector2 thumbstickPos = OVRInput.Get(axis, controller);
        bool isThumbstickMoved = (!isTumbstickTouched && !_ignoreTouch) || thumbstickPos.sqrMagnitude > thumbstickDistanceSq;

        bool validThisFrame = (isTumbstickTouched || _ignoreTouch) && isThumbstickMoved;
        if (validLastFrame && isTumbstickTouched && !_ignoreTouch) {
            validThisFrame = true;
        }

        Receive(validThisFrame || validLastFrame || validTwoFramesAgo);

        validTwoFramesAgo = validLastFrame;
        validLastFrame = validThisFrame;
    }
}
