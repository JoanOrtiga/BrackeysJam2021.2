using ChaosAlchemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortero : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int clickTimes = 3;
    [SerializeField]
    private Converter converter;
    [SerializeField]
    private GameObject maza;
    [SerializeField]
    private float heighMovement;
    [SerializeField]
    private float time;

    private Vector3 initialPos;
    private Vector3 finalPos;
    private bool movementUp;
    private bool movementDown;
    private float timer;

    private Ingredient ingredient;
    private int timesCounter;
    private bool picando;
    public void Interact()
    {
        picando = true;
        CameraController.CameraFix(true);
    }

    private void Start()
    {
        initialPos = maza.transform.position;
        finalPos = initialPos + new Vector3(0, heighMovement, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponent("Ingredient") as Ingredient) != null)
        {
            ingredient = other.GetComponent("Ingredient") as Ingredient;
            timesCounter = 0;
        }
    }
    private void Update()
    {
        Debug.Log(timesCounter);
        if (picando)
        {
            if (timesCounter >= clickTimes && movementDown)
            {
                if (!(ingredient is null))
                    converter.CovertIngredient(ingredient);
                CameraController.CameraFix(false);
                picando = false;
                timesCounter = 0;
            }

            if (Input.GetKeyDown(KeyCode.E) && movementDown)
            {
                timesCounter++;
                movementUp = true;
                movementDown = false;
            }
            else if (movementUp)
            {
                timer += Time.deltaTime;
                var heighAdded = Mathf.Lerp(0, heighMovement, timer / time);
                maza.transform.position = initialPos + new Vector3(0, heighAdded, 0);
                if (heighAdded >= heighMovement)
                {
                    movementUp = false;
                    timer = 0;
                }
            }
            else if (!movementUp && !movementDown)
            {
                timer += Time.deltaTime;
                var heighAdded = Mathf.Lerp(0, heighMovement, timer / time);
                maza.transform.position = finalPos - new Vector3(0, heighAdded, 0);
                if (heighAdded >= heighMovement)
                {
                    movementDown = true;
                    timer = 0;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.GetComponent("Ingredient") as Ingredient) != null)
        {
            ingredient = null;
            timesCounter = 0;
        }
    }
}
