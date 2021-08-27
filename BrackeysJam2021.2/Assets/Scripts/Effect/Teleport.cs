using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Teleport : PotionEffect
{
    
    private List<SpawnerItem> spawnerItems;
    [SerializeField]
    private Vector3[] initialPos;

    private int random;

    public override void ActivePotionEffect()
    {
        TeleportSpawners();
    }

    private void Awake()
    {
        spawnerItems = FindObjectsOfType<SpawnerItem>().ToList();
        initialPos = new Vector3[spawnerItems.Count];        
    }

    private void TeleportSpawners() //FUNCIÓN PARA ACTIVAR
    {

        for (int i = 0; i < spawnerItems.Count; i++)
        {
            initialPos[i] = spawnerItems[i].transform.position;
        }

        random = Random.Range(1, spawnerItems.Count); 

        for (int i = 0; i < spawnerItems.Count; i++)
        {
            spawnerItems[i].transform.position = initialPos[random];
            random++;

            if (random >= spawnerItems.Count) //pendiente de cambir
                random = 0;

        }
    }
    public override void StopPotionEffect()
    {
       
    }
  
}
