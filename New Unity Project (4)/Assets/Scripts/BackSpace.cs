using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSpace : UIButtonBase
{
    void Update()
    {
        if (triggerd)
        {
            GameManager.instance.nameMan.RemoveLetter();
            triggerd = false;
        }
    }
}
