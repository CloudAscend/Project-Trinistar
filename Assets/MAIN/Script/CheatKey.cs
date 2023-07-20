using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatKey : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (Input.GetKey(KeyCode.V))
        {
            SceneManager.LoadScene("Stage 2");
        }
    }
}
