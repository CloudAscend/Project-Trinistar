using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "Start Button") SceneManager.LoadScene("Stage 1-00");
        else if (gameObject.name == "Exit Button")
        {
            Application.Quit();
        }
        else if (gameObject.name == "How To Button")
        {

        }

    }
}
