using System.Collections.Generic;
using UnityEngine;

public class PotionsManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> potionsGOList;
    [SerializeField]
    private GameObject badPotionGO;

    private static List<GameObject> potionsList;
    public static GameObject badPotion;

    private void Awake()
    {
        potionsList = new List<GameObject>();
        badPotion = badPotionGO;

        foreach (GameObject potion in potionsGOList)
        {
            potionsList.Add(potion.gameObject);
        }
    }

    public static GameObject GetPotion(string potionName)
    {
        foreach (GameObject potion in potionsList)
        {
            if (string.Equals(potion.GetComponent<Potion>().GetName(), potionName))
                return potion;
        }
        return null;
    }
    public static GameObject GetBadPotion()
    {
        return badPotion;
    }
}
