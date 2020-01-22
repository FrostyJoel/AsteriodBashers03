using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : UIButtonBase
{
    public string letter;

    private void Update()
    {
        if (triggerd)
        {
            GameManager.instance.nameMan.AddLetter(letter);
            triggerd = false;
        }
    }
}
