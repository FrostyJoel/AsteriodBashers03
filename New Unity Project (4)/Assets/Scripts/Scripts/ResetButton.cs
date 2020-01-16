using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : UIButtonBase
{
    // Update is called once per frame
    void Update()
    {
        if (triggerd)
        {
            GameManager.instance.uiMan.ResetGame();
        }
    }
}
