using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCharacter : MonoBehaviour
{ 
    public GameObject dialogueBox;
    public Transform player;
    public Text message;

    public GameObject[] monster;

    private bool actInterface;
    private bool actTrigger = true;

    private Animator anime;
    private SpriteRenderer sprite;
    private void Awake()
    {
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.flipX = player.position.x < transform.position.x == true;

        if (actInterface && Input.GetKeyDown(KeyCode.W))
        {
            actInterface = false;
            message.text = " ";
            for (int i = 0; i < monster.Length; i++)
                monster[i].SetActive(true);
            StartCoroutine(Dialogue());
        }
    }

    IEnumerator Dialogue()
    {
        dialogueBox.SetActive(true);
        actTrigger = false;
        yield return new WaitForSeconds(1f);
        dialogueBox.SetActive(false);
        anime.SetTrigger("disappear");
        yield return new WaitForSeconds(1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && actTrigger)
        {
            actInterface = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && actInterface)
        {
            actInterface = false;
            message.text = " ";
        }
    }
}
