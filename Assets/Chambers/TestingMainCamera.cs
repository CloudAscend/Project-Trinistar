using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMainCamera : MonoBehaviour
{
    public Transform player;
    public Transform pen;
    private void Update()
    {
        float lerpX = (player.position.x + pen.position.x) / 2;
       
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, lerpX, Time.deltaTime * 10), 0, -10);
    }
}
