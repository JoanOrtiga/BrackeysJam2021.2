using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trituradora : Interactable
{
    [SerializeField]
    private float rad = 3f;
    [SerializeField]
    private float power = 7f;
    [SerializeField]
    private float upForce = 2.5f;

    [SerializeField]
    private int splitNumber = 7;

    [SerializeField]
    private Converter converter;

    private bool activated = false;
    private bool converted = false;

    private int ingredientsInside;

    private void Update()
    {
        if (ingredientsInside <= 0)
        {
            converted = false;
            ingredientsInside = 0;
        }
    }
    public override void Active()
    {
        activated = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!converted)
        {
            if ((other.GetComponent("Ingredient") as Ingredient) != null)
            {
                ingredientsInside++;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.GetComponent("Ingredient") as Ingredient) != null)
        {
            if (activated)
            {
                Ingredient ingredient = other.GetComponent("Ingredient") as Ingredient;
                for (int i = 0; i < splitNumber; i++)
                {
                    converter.CovertIngredient(ingredient);
                    ingredientsInside++;
                }
                ingredientsInside--;
                activated = false;
                converted = true;
            }
            if (converted)
            {
                if (ingredientsInside > 0)
                {
                    other.GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, rad, upForce, ForceMode.Impulse);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.GetComponent("Ingredient") as Ingredient) != null)
        {
            ingredientsInside--;
        }
    }
}
