using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextScene;

    public Image image;
    //public Animation anim;
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            image.GetComponent<Animator>().SetBool("StageChange", true);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(nextScene);
        }
    }
}
