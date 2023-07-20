using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeShowText : MonoBehaviour
{
    public Text hp;
    public Text mp;

    public GameObject player;

    private HPSystem hpSystem;
    private void Start()
    {
        hpSystem = GetComponent<HPSystem>();
    }

    private void Update()
    {
        hp.text = "HP: " + hpSystem.hp;
    }
}
