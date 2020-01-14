using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnpoints : MonoBehaviour
{
    public List<AstroidWave> astroidWave = new List<AstroidWave>();
    public List<Transform> spawnLoc = new List<Transform>();
    public int wave;
    public float spawnTime;
    public float cooldownTime;

    public void StartGame()
    {
        StartCoroutine(StartAstroidSpawn());
        StartCoroutine(GameManager.instance.ship.FuelUsage());
    }
    public IEnumerator StartAstroidSpawn()
    {
        while (true)
        {
            if(wave < astroidWave.Count)
            {
                int backUpWave = wave;
                wave++;
                for (int i = 0; i < astroidWave[backUpWave].wave.Count; i++)
                {
                    StartCoroutine(SpawnAstroid(astroidWave[backUpWave].wave[i].amount,backUpWave,i));
                    
                    yield return new WaitForSeconds(astroidWave[backUpWave].wave[i].amount * cooldownTime);
                }
            }
            yield break;
        }
    }

    IEnumerator SpawnAstroid(int Maxamount,int actualWave, int currentWave)
    {
        int amount = 0;
        while (true)
        {
            int randomObject = Random.Range(0, astroidWave[actualWave].wave[currentWave].spaceStuff.Length);
            //Debug.Log(randomObject);
            int randomplace = Random.Range(0, spawnLoc.Count);
            //Debug.Log(randomLocation.position);
            amount++;
            Instantiate(astroidWave[actualWave].wave[currentWave].spaceStuff[randomObject], spawnLoc[randomplace].position,spawnLoc[randomplace].rotation);
            if (amount >= Maxamount)
            {
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
    
    [System.Serializable]
    public struct AstroidWave
    {
        [SerializeField] public List<AstroidWaveAmount> wave;
    }
    [System.Serializable]
    public struct AstroidWaveAmount
    {
        [SerializeField] public int amount;
        [SerializeField] public GameObject[] spaceStuff;
    }
}
