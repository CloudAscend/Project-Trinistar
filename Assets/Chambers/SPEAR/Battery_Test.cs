using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Test : MonoBehaviour
{
    public GameObject battery;

    private bool batteryShow;
    private void Start()
    {
        batteryShow = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && batteryShow)
        {
            Instantiate(battery, new Vector3(transform.position.x, 2.5f, 0), Quaternion.identity);
            batteryShow = false;
            StartCoroutine(BatteryCharge());
        }
    }

    IEnumerator BatteryCharge()
    {
        yield return new WaitForSeconds(5.0f);
        if (battery != null)
            Destroy(battery.gameObject);
        //batteryShow = true;
    }
}
