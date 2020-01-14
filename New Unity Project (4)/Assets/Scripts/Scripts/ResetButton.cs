using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : UIButtonBase
{
    public GameObject startScreen;
    // Update is called once per frame
    void Update()
    {
        if (triggerd)
        {
            GameManager.instance.uiMan.ResetGame(startScreen);
            mainCanvas.SetActive(false);
            triggerd = false;
        }
    }
}
