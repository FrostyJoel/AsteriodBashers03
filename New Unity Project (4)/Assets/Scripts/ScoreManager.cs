using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public Text[] scoreSlots;
    public List<Score> names = new List<Score>();
    public Score highScore;
    public int maxNames;

    private void Start()
    {
        GameManager.instance.saveLoad.Load();
        SetHighScore();
        UpdateUI();
    }

    public void SetHighScore()
    {
        if (highScore.name == "" || highScore.name == null)
        {
            highScore.name = "Guest";
        }
    }
    public void SetScore(Score score)
    {
        if (score.name == "")
        {
            score.name = "Guest";
        }
        if (score.score < highScore.score)
        {
            names.Insert(1, score);
        }
        else
        {
            highScore = score;
            names.Insert(0, score);
        }
        if (names.Count > scoreSlots.Length)
        {
            names.RemoveAt(names.Count - 1);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < scoreSlots.Length; i++)
        {
            if (names[i].name != "")
            {
                scoreSlots[i].text = "Name: " + names[i].name.ToString() + "\n" + "Score: " + names[i].score.ToString();
            }
        }
        SaveUI();
    }

    public void SaveUI()
    {
        GameManager.instance.saveLoad.Save();
    }

    [System.Serializable]
    public struct Score
    {
        [SerializeField] public string name;
        [SerializeField] public float score;
    }
}
