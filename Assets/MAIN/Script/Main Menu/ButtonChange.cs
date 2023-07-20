using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public GameObject mainButton;
    public int next;

    private void OnMouseDown()
    {
        mainButton.GetComponent<MainButton>().buttonState += next;
        //StartCoroutine(mainButton());
    }
}
