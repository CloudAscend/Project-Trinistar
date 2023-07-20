using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLazer : MonoBehaviour
{
    public Transform pointer;
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //ÇÔ¼öÈ­
            transform.localScale += new Vector3(1, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);

            float rad = Mathf.Atan2(pointer.position.y, pointer.position.x);
            float deg = rad * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, deg);
        }
    }
}
