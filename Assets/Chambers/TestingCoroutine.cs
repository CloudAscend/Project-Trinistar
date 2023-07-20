using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(tryCoroutine());
    }

    IEnumerator tryCoroutine()
    {
        Debug.Log($"Coroutine 실행!!{Time.time}");
        yield return new WaitForSeconds(1.0f); //1초 딜레이
        Debug.Log($"Coroutine 실행!!{Time.time}");
    }
}
