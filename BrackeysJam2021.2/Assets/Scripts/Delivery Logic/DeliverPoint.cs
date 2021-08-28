using System;
using System.Collections;
using System.Collections.Generic;
using ChaosAlchemy;
using UnityEngine;

public class DeliverPoint : MonoBehaviour
{
    [SerializeField] private float timeUntilDissapear;
    
    //[SerializeField] private OrdersManager ordersManager;

    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Potion>() != null)
        {
            StartCoroutine(TimeUntilDissapear(other.gameObject));
        }

        /*
        if ((other.GetComponent("Potion") as Potion) != null)
        {
            Destroy(other);
            ordersManager.Puntuation();
        }
        */
    }

    IEnumerator TimeUntilDissapear(GameObject potion)
    {
        yield return new WaitForSeconds(timeUntilDissapear);
        _gameController.EndPotion();
        Destroy(potion);
    }
}
