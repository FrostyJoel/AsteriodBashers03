using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonBase : MonoBehaviour
{
    public Image buttonTrigger;
    public bool triggerd;

    public virtual void Selected()
    {
        Debug.Log("Selected");
        if(buttonTrigger != null)
        {
            buttonTrigger.color = Color.green;
        }
    }
}
