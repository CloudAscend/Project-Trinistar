using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingColor : MonoBehaviour
{
    private float rateTime;

    public SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log(sprite.color);
    }

    private void FixedUpdate()
    {
        sprite.color = new Color(1, 141 / 255f, 141 / 255f, 1);
        Debug.Log(sprite.color);
        /*
        if (rateTime < Time.time)
        {
            rateTime = Time.time + 0.5f;
            sprite.color -= new Color(0, 0.1f, 0.1f, 0);
        }
        */
    }
}
