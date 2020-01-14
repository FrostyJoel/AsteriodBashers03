using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Pointer : MonoBehaviour
{
    public float dis = 10.0f;
    public LineRenderer line = null;
    public LayerMask everythingMask = 0;
    public LayerMask interactableMask = 0;
    public UnityAction<Vector3, GameObject> onPointerUpdate = null;

    private Transform curOrigen = null;
    private GameObject currentObject = null;

    private void Awake()
    {
        PlayerEvents.onControllerSource += UpdateOrigin;
        PlayerEvents.onTouchpadDown += ProcessTouchPadDown;
    }

    private void Start()
    {
        SetLineColor();
    }

    private void OnDestroy()
    {
        PlayerEvents.onControllerSource -= UpdateOrigin;
        PlayerEvents.onTouchpadDown -= ProcessTouchPadDown;
    }

    private void Update()
    {
        Vector3 hitPoint = UpdateLine();

        currentObject = UpdatePointerStatus();

        if(onPointerUpdate != null)
        {
            onPointerUpdate(hitPoint, currentObject);
        }
    }

    private Vector3 UpdateLine()
    {
        // Create ray
        RaycastHit hit = CreateRaycast(everythingMask);

        // Default end
        Vector3 endPos = curOrigen.position + (curOrigen.forward * dis);

        // Check hit
        if(hit.collider != null)
        {
            endPos = hit.point;
        }

        // Set Pos
        line.SetPosition(0, curOrigen.position);
        line.SetPosition(1, endPos);

        return endPos;
    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        // Set Origen of pointer
        curOrigen = controllerObject.transform;

        // Is the laser Visible?
        if(controller == OVRInput.Controller.Touchpad)
        {
            line.enabled = false;
        }
        else
        {
            line.enabled = true;
        }
    }

    private GameObject UpdatePointerStatus()
    {
        //Create Ray
        RaycastHit hit = CreateRaycast(interactableMask);

        //Create Hit
        if (hit.collider)
        {
            return hit.collider.gameObject;
        }

        //Return
        return null;
    }

    public RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(curOrigen.position, curOrigen.forward);
        Physics.Raycast(ray, out hit, dis, layer);

        return hit;
    }

    public void SetLineColor()
    {
        if (!line)
        {
            return;
        }
        Color endColor = Color.white;
        endColor.a = 0;
        line.endColor = endColor;
    }

    private void ProcessTouchPadDown()
    {
        if (!currentObject)
        {
            return;
        }
        GetComponent<Player>().Interactible(CreateRaycast(interactableMask));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, transform.forward*dis);
    }
}
