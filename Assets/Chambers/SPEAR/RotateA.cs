using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateA : MonoBehaviour
{
    public Transform target;
    public Transform site;
    private void Update()
    {
        float rad = Mathf.Atan2(target.position.y - transform.position.y, 
                                target.position.x - transform.position.x);
        float deg = rad * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, deg);
        site.localScale = new Vector3((target.position.x - transform.position.x), 0.5f, 0);
        //site.position += new Vector3(1, 0, 0);
    }
}
