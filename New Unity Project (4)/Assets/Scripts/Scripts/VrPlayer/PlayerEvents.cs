using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region Events
    public static UnityAction onTouchpadUp = null;
    public static UnityAction onTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> onControllerSource;
    #endregion

    #region Anchors
    public GameObject LeftAnchor;
    public GameObject RightAnchor;
    public GameObject HeadAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> controllerSets = null;
    private OVRInput.Controller inputSource = OVRInput.Controller.None;
    private OVRInput.Controller controller = OVRInput.Controller.None;
    private bool inputActive = true;
    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;
        controllerSets = CreateContollerSets();
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    private void Update()
    {
        //Check for active Input
        if (!inputActive)
        {
            return;
        }
        // Check if controler exists
        CheckForController();

        // Check for input source
        CheckInputSource();

        //Check for actual Input
        Input();
    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = controller;

        //Right Remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        }

        //Left Remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        }

        //If no controllers, headset
        if (!OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote) && !OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.Touchpad;
        }

        //Update 
        controller = UpdateSource(controllerCheck, controller);
    }

    private void CheckInputSource()
    {
        //Update
        inputSource = UpdateSource(OVRInput.GetActiveController(), inputSource);
    }

    private void Input()
    {
        //TouchpadDown
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if(onTouchpadDown != null)
            {
                onTouchpadDown();
            }
        }
        //ToudchpadUp
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (onTouchpadUp != null)
            {
                onTouchpadUp();
            }
        }
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check,OVRInput.Controller previous)
    {
        //If values are the same, return
        if(check == previous)
        {
            return previous;
        }

        //Get controller object
        GameObject controllerObject = null;
        controllerSets.TryGetValue(check, out controllerObject);

        //If no controller, set to head
        if(controllerObject == null)
        {
            controllerObject = HeadAnchor;
        }

        //Send out event
        if(onControllerSource != null)
        {
            onControllerSource(check, controllerObject);
        }

        //Return new Value
        return check;
    }

    private void PlayerFound()
    {
        inputActive = true;
    }

    private void PlayerLost()
    {
        inputActive = false;
    }

    private Dictionary<OVRInput.Controller,GameObject> CreateContollerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            {OVRInput.Controller.LTrackedRemote,LeftAnchor },
            {OVRInput.Controller.RTrackedRemote,RightAnchor},
            {OVRInput.Controller.Touchpad,HeadAnchor }
        };
        return newSets;
    }
}
