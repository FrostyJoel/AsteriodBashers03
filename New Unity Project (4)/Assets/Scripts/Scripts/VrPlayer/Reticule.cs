using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{
    public Pointer pointer;
    public SpriteRenderer circleRender;

    public Sprite openSprite;
    public Sprite closedSprite;

    private Camera cam = null;

    private void Awake()
    {
        pointer.onPointerUpdate += UpdateSprite;
        cam = Camera.main;
    }

    private void OnDestroy()
    {
        pointer.onPointerUpdate -= UpdateSprite;
    }

    private void Update()
    {
        transform.LookAt(cam.transform);
    }

    private void UpdateSprite(Vector3 point, GameObject hitobject)
    {
        transform.position = point;
        if (hitobject)
        {
            circleRender.sprite = closedSprite;
        }
        else
        {
            circleRender.sprite = openSprite;
        }
    }
}
