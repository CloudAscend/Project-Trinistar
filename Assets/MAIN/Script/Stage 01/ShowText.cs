using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text mp;

    private MPSystem mpSystem;
    private void Start()
    {
        mpSystem = GetComponent<MPSystem>();
    }

    private void Update()
    {
        string h = "";
        if (mpSystem.mp == 0) h = " 충전 필요!!!";
        else h = "";
        mp.text = "MP: " + mpSystem.mp + "%" + h;
    }
}
