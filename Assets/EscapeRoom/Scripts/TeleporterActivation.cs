using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class TeleporterActivation : BooleanAction
{
    public OVRInput.Controller controller = OVRInput.Controller.Active;

    [SerializeField] private bool ignoreTouch;

    protected OVRInput.Touch touch = OVRInput.Touch.PrimaryThumbstick;
    protected OVRInput.Axis2D axis = OVRInput.Axis2D.PrimaryThumbstick;
    protected float thumbstickDistanceSq = 0.75f * 0.75f;
    protected bool validLastFrame = false;
    protected bool validTwoFramesAgo = false;

    void Update() {
        bool isTumbstickTouched = OVRInput.Get(touch, controller);
        Vector2 thumbstickPos = OVRInput.Get(axis, controller);
        bool isThumbstickMoved = (!isTumbstickTouched && !ignoreTouch) || thumbstickPos.sqrMagnitude > thumbstickDistanceSq;

        bool validThisFrame = (isTumbstickTouched || ignoreTouch) && isThumbstickMoved;
        if (validLastFrame && isTumbstickTouched && !ignoreTouch) {
            validThisFrame = true;
        }

        Receive(validThisFrame || validLastFrame || validTwoFramesAgo);

        validTwoFramesAgo = validLastFrame;
        validLastFrame = validThisFrame;
    }
}
