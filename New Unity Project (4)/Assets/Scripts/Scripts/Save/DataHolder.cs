using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataHolder
{
    public ScoreManager.Score[] scores;
    public ScoreManager.Score highScore = new ScoreManager.Score();
}
