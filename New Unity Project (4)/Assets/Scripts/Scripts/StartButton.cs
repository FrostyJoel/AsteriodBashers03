using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : UIButtonBase
{
    public GameObject nameEnterLeft;
    public GameObject titleCard;
    public GameObject _TextLeft;
    public bool isStartingGameButton;

    void Update()
    {
        if (triggerd)
        {
            if (nameEnterLeft.activeSelf == false)
            {
                nameEnterLeft.SetActive(true);

                _TextLeft.SetActive(false);
            }

            else
            {
                GameManager.instance.player.namePlayer = nameEnterLeft.GetComponent<InputField>().textComponent.text;
                GameManager.instance.uiMan.StartGame();
            }

            triggerd = false;
            mainCanvas.SetActive(false);

            if (isStartingGameButton)
            {
                _TextLeft.SetActive(true);
            }
            else
            {
                titleCard.SetActive(false);
            }
        }
    }
}
