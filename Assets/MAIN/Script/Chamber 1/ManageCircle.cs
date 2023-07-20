using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCircle : MonoBehaviour
{
    public GameObject[] circle;

    private void FixedUpdate()
    {
        Debug.Log(circle.Length);
    }
}
