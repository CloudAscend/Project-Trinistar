using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingBoss : MonoBehaviour
{
    private Animation anim;
    private void Awake()
    {
        anim = GetComponent<Animation>();
        //anim. = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("TESTING");
            anim.enabled = true;
        }
    }
}
