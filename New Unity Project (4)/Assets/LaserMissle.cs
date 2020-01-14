using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMissle : MonoBehaviour
{
    public float maxTime;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
    public void Timer()
    {
        currentTime += Time.deltaTime;
        if(currentTime > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
