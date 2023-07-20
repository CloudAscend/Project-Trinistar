using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingController : MonoBehaviour
{
    public Transform standing;
    public SpriteRenderer[] weaponStand;

    private bool flipSprite;

    private PlayerMovement pMove;

    private void Start()
    {
        for (int i = 0; i < weaponStand.Length; i++)
            weaponStand[i] = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //flipSprite = pMove.move < 0 == true;
        Debug.Log(flipSprite);

        SpriteFlip(flipSprite);
    }

    private void SpriteFlip(bool fs)
    {
        for (int i = 0; i < weaponStand.Length; i++)
            if (weaponStand != null)
                weaponStand[i].flipX = fs;

        if (fs)
        {
            standing.position = new Vector2(transform.position.x + 3.5f, standing.position.y);
        }
        else
        {
            standing.position = new Vector2(transform.position.x - 3.5f, standing.position.y);
        }
    }
}
