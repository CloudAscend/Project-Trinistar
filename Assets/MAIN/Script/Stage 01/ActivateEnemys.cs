using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemys : MonoBehaviour
{
    public GameObject[] monster;
    public Transform cameraPos;

    private bool actInterface;

    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (actInterface && Input.GetKeyDown(KeyCode.W))
        {
            actInterface = false;
            for (int i = 0; i < monster.Length; i++)
                monster[i].SetActive(true);
            StartCoroutine(OnSwitch());
        }
    }

    IEnumerator OnSwitch()
    {
        sprite.color = new Color(100 / 255f, 1, 100 / 255f, 1);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !actInterface)
        {
            actInterface = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && actInterface)
        {
            actInterface = false;
        }
    }
}
