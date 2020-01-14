using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBase : MonoBehaviour
{
    public bool triggerd;
    public GameObject mainCanvas;

    public void Trigger()
    {
        triggerd = true;
    }
}
