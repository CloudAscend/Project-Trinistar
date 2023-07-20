using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public GameObject[] credit;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < credit.Length; i++)
        {
            credit[i].SetActive(true);
            yield return new WaitForSeconds(2f);
            credit[i].SetActive(false);
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene("Main Menu");
    }
}
