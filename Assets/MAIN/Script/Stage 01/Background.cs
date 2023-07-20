using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed; //0.01f
    public float dist;

    //public Transform mainCamera;

    public GameObject player;
    public Transform[] background;

    private float a = -24f;

    private int listN;

    private void Update()
    {
        background[listN % 2].position += new Vector3(player.GetComponent<PlayerMovement>().move, 0, 0) * 0.1f * speed;
        if (Mathf.Round(background[listN % 2].position.x) == a * player.GetComponent<PlayerMovement>().move)
        {
            background[listN % 2].position = new Vector3(background[(listN + 1) % 2].position.x + a, -1.5f, 0);
            listN += 1;
        }
    }

    /*
    private void Update()
    {
        foreach (var item in background)
        {
            item.Translate(Vector3.right * Time.deltaTime * moveSpeed);

            if (item.position.x >= dist)
            {
                var pos = item.position;
                pos.x += dist * -2f;
                item.position = pos;
            }
        }
    }
    */

    /*
    private void Update()
    {
        if (player.transform.position.x > 0 && player.transform.position.x < 48)
            transform.position = new Vector3(player.transform.position.x, 0.5f, 0);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < background.Length; i++)
        {
            float playerSpeed = player.GetComponent<PlayerMovement>().move;
            if (player.transform.position.x > 0 && player.transform.position.x < 48)
                background[i].GetComponent<Animator>().speed = Mathf.Abs(playerSpeed);
            else
                background[i].GetComponent<Animator>().speed = 0;
        }
    }
    */
}
