using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInk : MonoBehaviour
{   
    private void Update()
    {
        if (transform.parent == null) {
            transform.Translate(Vector2.right * 0.1f);
            transform.localScale += new Vector3(0.2f, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0);
        }
    }
}
