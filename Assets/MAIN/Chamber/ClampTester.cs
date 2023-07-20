using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampTester : MonoBehaviour
{
    private float i;

    private bool k = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && k)
        {
            Debug.Log("Activate");
            i += 1;
        }
        i = Mathf.Clamp(i, 0, 1);
        Debug.Log(i);
    }
}
