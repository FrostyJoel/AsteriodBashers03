using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    //public Image fuelBar;

    public Text score;
    public Text fuel;

    public Text laserText;
    public Text MagnetText;
    public Text shieldText;
    public Text missileText;

    public Text gameOverText;
    public float maxFuel, fuelLeft, scoreGot;
    

    public Weapons lasers;
    public Weapons magnet;
    public Weapons shield;

    void Update()
    {
        if (fuelLeft > 0)
        {
            //fuelBar.fillAmount = fuelLeft / maxFuel;
            fuel.text = "Huidige Brandstof; " + Mathf.RoundToInt(fuelLeft).ToString();

        }
        else
        {
            fuel.text = "Huidige Brandstof: Leeg";
        }

        score.text = "Meters gevlogen: " + Mathf.RoundToInt(scoreGot).ToString();

        if (lasers.readyToFire)
        {
            laserText.text = "Lasers: Gereed";
        }

        else if (!lasers.readyToFire)
        {
            laserText.text = "Lasers: opladen";
        }

        if (shield.readyToFire)
        {
            shieldText.text = "Schild: gereed";
        }

        else if (!shield.readyToFire)
        {
            shieldText.text = "Schild: opladen";
        }

        if (magnet.readyToFire)
        {
            MagnetText.text = "Magneet: gereed";
        }

        else if (!magnet.readyToFire)
        {
            MagnetText.text = "Magneet: opladen";
        }


    }

    public void Leave()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(Score());
        GameManager.instance.soundMan.StopAllMusic();
        GameManager.instance.soundMan.Play("InGameMusic");
        GameManager.instance.spawnPoint.StartGame();
    }

    public void ResetGame()
    {
        //TODO GO TO MENU SCENE
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameManager.instance.spawnPoint.StopAllCoroutines();
        gameOverText.text = "GameOver" + "\n" + "Score: " + scoreGot.ToString();
        GameManager.instance.scoreMan.SetScore(new ScoreManager.Score { name = GameManager.instance.player.namePlayer, score = scoreGot });
        GameOverScreen.SetActive(true);
        score.enabled = false;
        fuel.enabled = false;

    }

    private IEnumerator Score()
    {
        while (true)
        {
            scoreGot += GameManager.instance.ship.speed;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
