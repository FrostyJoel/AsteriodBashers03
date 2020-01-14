using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Managers")]
    public WeaponManager weaponMan;
    public SoundMan soundMan;
    public RandomSpawnpoints spawnPoint;
    public ButtonManager buttonMan;
    public UiManager uiMan;
    public Ship ship;
    public ScoreManager scoreMan;
    public Player player;
    public SaveLoading saveLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
