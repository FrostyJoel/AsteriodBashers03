using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkScript : MonoBehaviour
{
    public GameObject[] junk;

    private void Start()
    {
        int randomJunk = Random.Range(0, junk.Length);
        GetComponentInChildren<MeshFilter>().sharedMesh = junk[randomJunk].GetComponent<MeshFilter>().sharedMesh;
    }
}
