using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateBattery : MonoBehaviour
{
    public GameObject spear;

    public Sprite[] battery;
    public Text message;

    private int mp;
    private float timeRate;

    private bool actInterface;
    private bool charging;

    private Animator anime;
    private SpriteRenderer sprite;
    //OnTriggerStay 쓰지 말것!

    //state =
    private void Awake()
    {
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (actInterface && Input.GetKeyDown(KeyCode.W))
        {
            actInterface = false;
            charging = true;
            message.text = " ";
            anime.SetBool("BatteryState", true);
            StartCoroutine(OnSwitch());
        }

        if (actInterface && !charging) message.text = "Press [W] To Charge";
    }

    private void FixedUpdate()
    {

    }

    IEnumerator OnSwitch()
    {
        yield return new WaitForSeconds(10f);
        actInterface = false;
        yield return new WaitForSeconds(8f);
        anime.SetBool("BatteryState", false);
        charging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !charging)
        {
            actInterface = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") && charging && timeRate <= Time.time)
        {
            timeRate = Time.time + 1;
            spear.GetComponent<MPSystem>().mp += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && charging)
        {
            charging = false;
            actInterface = false;
            message.text = " ";
        }
    }
}
