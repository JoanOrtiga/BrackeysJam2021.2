using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{
    [SerializeField]
    private Converter converter;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponent("Heating") as Heating) != null)
        {
            other.gameObject.GetComponent<Heating>().Converter = converter;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.GetComponent("Heating") as Heating) != null)
        {
            Debug.Log("Heating");
            other.gameObject.GetComponent<Heating>().timeHeated += Time.deltaTime;
        }
    }
}
