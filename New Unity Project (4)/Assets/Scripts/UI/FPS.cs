using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text fpsText;
    public float framesPerSecond;

    void Update()
    {
        framesPerSecond += (Time.deltaTime - framesPerSecond) * 0.1f;
        float fps = 1.0f / framesPerSecond;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
