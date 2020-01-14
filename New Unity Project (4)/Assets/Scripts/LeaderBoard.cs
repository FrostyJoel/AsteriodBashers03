using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : UIButtonBase
{
    public GameObject leaderBoardR;
    public GameObject leaderBoardL;

    private void Update()
    {
        if (triggerd)
        {
            GameManager.instance.saveLoad.Load();
            if (leaderBoardL != null)
            {
                leaderBoardL.SetActive(true);
            }
            if (leaderBoardR != null)
            { 
                leaderBoardR.SetActive(true);
            }
            mainCanvas.SetActive(false);
            triggerd = false;
        }
    }
}
