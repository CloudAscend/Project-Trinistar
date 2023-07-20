using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeTurnStanding : MonoBehaviour
{
    public GameObject player;

    private float counter;

    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float o = player.GetComponent<PlayerMovement>().move;
        if (o < 0)
        {
            sprite.flipX = true;
            counter = player.transform.position.x + 1.5f;
        }
        if (o > 0)
        {
            sprite.flipX = false;
            counter = player.transform.position.x - 1.5f;
        }

        //transform.position = new Vector3(player.transform.position, )

        //transform.position = Mathf.Lerp(transform.position, counter, Time.deltaTime * 2.5f);

        counter = Mathf.Lerp(transform.position.x, counter, Time.deltaTime * 10f);

        transform.position = new Vector3(counter, transform.position.y, 0);
    }
}
