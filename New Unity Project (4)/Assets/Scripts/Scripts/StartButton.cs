using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : UIButtonBase
{
    public GameObject nameEnterLeft;
    public GameObject titleCard;
    public GameObject _TextLeft;
    public GameObject keyBoard;
    public bool isStartingGameButton;

    void Update()
    {
        if (triggerd)
        {
            if (nameEnterLeft.activeSelf == false)
            {
                nameEnterLeft.SetActive(true);

                keyBoard.SetActive(true);
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
                titleCard.SetActive(true);
                _TextLeft.SetActive(true);
                keyBoard.SetActive(false);
            }
            else
            {
                titleCard.SetActive(false);
            }
        }
    }
}
