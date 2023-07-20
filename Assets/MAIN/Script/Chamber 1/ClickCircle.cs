using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCircle : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
