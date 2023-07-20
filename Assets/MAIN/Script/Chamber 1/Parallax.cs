using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material mat;
    private float distance;

    public float speed;

    public bool left;

    private int oppo;
    private void Start()
    { 
        mat = GetComponent<Renderer>().material;

        if (left)
            oppo = -1;
        else
            oppo = 1;
    }

    private void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.left * oppo * distance);
    }
}
