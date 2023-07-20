using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPSystem : MonoBehaviour
{
    public int mp;

    private SpearController spear;
    private void Awake()
    {
        mp = 100;
        spear = GetComponent<SpearController>();
    }

    private void FixedUpdate()
    {
        if (spear.state == 1) mp -= 1;
        mp = Mathf.Clamp(mp, 0, 100);
    }
}
