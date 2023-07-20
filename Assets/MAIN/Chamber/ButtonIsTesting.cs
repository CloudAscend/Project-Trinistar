using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIsTesting : MonoBehaviour
{
    public int button;

    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();    
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector2(7, 2);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector2(5, 1);
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector2(2.5f, 0.5f);
    }

    private void FixedUpdate()
    {
        switch (button)
        {
            case 0:
                sprite.color = new Color(255, 0, 0);
                break;
            case 1:
                sprite.color = new Color(255, 255, 0);
                break;
            case 2:
                sprite.color = new Color(255, 0, 255);
                break;
            case 3:
                sprite.color = new Color(255, 255, 255);
                break;
            default:
                if (button == 4)  button = 0;
                if (button == -1) button = 3;
                break;
        }
    }
}
