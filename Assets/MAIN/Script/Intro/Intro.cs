using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(13f);
        SceneManager.LoadScene("Main Menu");
    }
}
