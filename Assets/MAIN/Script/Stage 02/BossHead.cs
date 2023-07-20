using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHead : MonoBehaviour
{
    public int phase;
    public float delayTime;

    [Header("Hands")]
    public GameObject rightHand;
    public GameObject leftHand;

    [Header("Enmeys")]
    public GameObject[] monster1;
    public GameObject[] monster2;

    public Image fade;

    private int attackType;
    private float timeRate;
    public bool active;

    private bool nome = true;
    private HPSystem bossHp;
    private void Awake()
    {
        active = true;
        bossHp = GetComponent<HPSystem>();
    }

    private void FixedUpdate()
    {
        if (bossHp.hp <= 0 && nome)
        {
            nome = false;
            fade.GetComponent<Animator>().SetBool("StageChange", true);
            SceneManager.LoadScene("Credit");
        }

        if (bossHp.hp <= bossHp.maxHp / 2 && active)
        {
            for (int i = 0; i < monster1.Length; i++)
            {
                monster1[i].SetActive(true);
            }
        }

        if (bossHp.hp <= bossHp.maxHp / 4 && active)
        {
            for (int i = 0; i < monster2.Length; i++)
            {
                monster2[i].SetActive(true);
            }
        }

        if (timeRate < Time.time && active)
        {
            active = false;
            //timeRate = delayTime + Time.time;
            attackType = Random.Range(0, 3);
            //TEST
            if (timeRate == 0) attackType = 0;

            timeRate = delayTime + Time.time;

            switch (attackType)
            {
                case 0:
                    rightHand.GetComponent<BossHand>().action = 2;
                    leftHand.GetComponent<BossHand>().action = 2;
                    break;
                case 1:
                    leftHand.GetComponent<BossHand>().action = 1;
                    break;
                case 2:
                    rightHand.GetComponent<BossHand>().action = 1;
                    break;
            }
        }
    }
}
