using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citys : MonoBehaviour
{
    public bool shit;

    public GameObject city1;
    private void Update()
    {
        /*
        if (shit)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }*/

        if (shit)
        {
            city1.GetComponent<Animator>().speed = 0f;
        }
        else 
        {
            city1.GetComponent<Animator>().speed = 1f;
        }
    }
}
