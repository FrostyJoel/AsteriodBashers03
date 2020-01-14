using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : UIButtonBase
{
    // Update is called once per frame
    void Update()
    {
        if (triggerd)
        {
            GameManager.instance.uiMan.Leave();
            Debug.Log("I leave");
            triggerd = false;
        }
    }
}
