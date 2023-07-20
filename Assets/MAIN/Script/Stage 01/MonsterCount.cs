using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCount : MonoBehaviour
{
    public Text monsterCounter;
    public Image fade;
    public Image buffCase;
    public GameObject buff;
    public GameObject[] monsterDamage;

    public Sprite nextSprite;

    public int count;

    private bool pass = true;
    private void Awake()
    {
        count = monsterDamage.Length;
    }

    private void FixedUpdate()
    {
        monsterCounter.text = " Monster: " + count;
        if (count == 0 && pass)
        {
            pass = false;
            StartCoroutine(ShowBuff());
        }
    }

    IEnumerator ShowBuff()
    {
        fade.GetComponent<Animator>().SetBool("HowTo", true);
        yield return new WaitForSeconds(0.5f);
        buff.SetActive(true);
        yield return new WaitForSeconds(4f);
        fade.GetComponent<Animator>().SetBool("HowTo", false);
        yield return new WaitForSeconds(0.2f);
        buffCase.sprite = nextSprite;
        buff.SetActive(false);
    }
}
