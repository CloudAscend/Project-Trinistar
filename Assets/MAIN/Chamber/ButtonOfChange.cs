using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOfChange : MonoBehaviour
{
    public bool left;

    public GameObject centerButton;

    private int ca;

    private SpriteRenderer sprite;
    private void Awake()
    {
        if (left)
            ca = -1;
        else
            ca = 1;

        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        centerButton.GetComponent<ButtonIsTesting>().button += ca;
        StartCoroutine(buttonSwitched());
        
    }

    IEnumerator buttonSwitched()
    {
        sprite.color = new Color(1, 1, 1, 170 / 255f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1, 1, 1, 1);
    }
}
