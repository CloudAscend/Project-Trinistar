using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public int buttonState;

    public Text saying;
    public Image fade;

    public Sprite[] icon;

    public GameObject logo;
    public GameObject howToShow;

    private string sayingText;
    private bool quit;
    private void FixedUpdate()
    {
        buttonState = buttonState % 4;
        logo.GetComponent<SpriteRenderer>().sprite = icon[buttonState];
        switch (buttonState + 1)
        {
            case 1:
                saying.text = "시작하시겠습니까?";
                break;
            case 2:
                saying.text = "조작법을 보시겠습니까?";
                break;
            case 3:
                saying.text = "크래딧을 보시겠습니까?";
                break;
            case 4:
                saying.text = "종료하시겠습니까?";
                break;
        }
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.25f, 1.25f);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    private void OnMouseDown()
    {
        //logo.GetComponent<Animator>().SetInteger("ButtonState", buttonState % 4 + 1);
        transform.localScale = new Vector2(1f, 1f);
        if (buttonState % 4 == 0) StartCoroutine(StartGame());
        if (buttonState % 4 == 1) StartCoroutine(ShowHowTo());
        if (buttonState % 4 == 2) SceneManager.LoadScene("Credit");
        if (buttonState % 4 == 3) Application.Quit();
    }

    IEnumerator StartGame()
    {
        fade.GetComponent<Animator>().SetBool("StageChange", true);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Stage 1-00");
    }

    IEnumerator ShowHowTo()
    {
        fade.GetComponent<Animator>().SetBool("HowTo", true);
        yield return new WaitForSeconds(0.5f);
        howToShow.SetActive(true);
        yield return new WaitForSeconds(3f);
        howToShow.SetActive(false);
        fade.GetComponent<Animator>().SetBool("HowTo", false);
    }
}
