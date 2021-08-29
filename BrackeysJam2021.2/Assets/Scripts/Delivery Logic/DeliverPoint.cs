using System;
using System.Collections;
using System.Collections.Generic;
using ChaosAlchemy;
using UnityEngine;

public class DeliverPoint : MonoBehaviour
{
    [SerializeField] private float timeUntilDissapear;
    private MusicManager musicManager;
    //[SerializeField] private OrdersManager ordersManager;

    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Potion>() != null)
        {
            musicManager.StartBattle();
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
        _gameController.EndRecipe();
        Destroy(potion);
    }
}
