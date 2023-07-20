using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] thing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < thing.Length; i++)
        {
            if (collision.gameObject.tag == thing[i].gameObject.tag)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
