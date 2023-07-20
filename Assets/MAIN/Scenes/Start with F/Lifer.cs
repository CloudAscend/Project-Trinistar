using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifer : MonoBehaviour
{
    public float delayTime;

    private int life;
    private float rateTime;

    private bool call;
    private void Awake()
    {
        call = true;
    }

    private void FixedUpdate()
    {
        if (rateTime < Time.time && call)
        {
            rateTime = delayTime + Time.time;
            life = Random.Range(0, 3);
            if (life == 0)
            {
                call = false;
                StartCoroutine(i());
            }
            Debug.Log(life);
        }
    }

    IEnumerator i()
    {
        yield return new WaitForSeconds(5f);
        call = true;
    }
}
