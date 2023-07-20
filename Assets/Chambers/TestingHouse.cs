using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHouse : MonoBehaviour
{
    public Transform house;
    private void Update()
    {
        house.localScale = new Vector3(5, 5, 1);
    }
}
