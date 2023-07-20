using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePen : MonoBehaviour
{
    public Transform pointer;
    private void Update()
    {
        float rad = Mathf.Atan2(transform.position.y - pointer.position.y,
                                       transform.position.x - pointer.position.x);
        float deg = rad * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, deg + 180);
    }
}
