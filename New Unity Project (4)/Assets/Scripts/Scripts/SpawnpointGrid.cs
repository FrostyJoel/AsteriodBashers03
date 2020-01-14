using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointGrid : MonoBehaviour
{
    public List<SpawnLoc> loc = new List<SpawnLoc>();
    public SpawnLoc spawnTile;
    public int xLocation, yLocation;
    public bool done;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GridCreation());
    }

    IEnumerator GridCreation()
    {
        for (int i = 0; i < xLocation; i++)
        {
            for (int j = 0; j < yLocation; j++)
            {
                SpawnLoc currentTile = Instantiate(spawnTile, new Vector3(transform.localPosition.x+i, transform.localPosition.y + j, transform.localPosition.z), spawnTile.transform.rotation);
                currentTile.xPos = i;
                currentTile.yPos = j;
                loc.Add(currentTile);
                yield return new WaitForSeconds(0.1f);
            }
        }
        done = true;
        yield break;
    }
}
