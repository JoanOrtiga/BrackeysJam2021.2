using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private List<SpawnerItem> spawnerItems;
    [SerializeField]
    public Vector3[] initialPos;

    private int random;

    private void Start()
    {
        spawnerItems = FindObjectsOfType<SpawnerItem>().ToList();
        initialPos = new Vector3[spawnerItems.Count];//funcas o q joder

        for (int i = 0; i < spawnerItems.Count; i++)
        {
            initialPos[i] = spawnerItems[i].transform.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            random = Random.Range(0, spawnerItems.Count); //del 0 al 3 por ejemplo.

            for (int i = 0; i < spawnerItems.Count; i++)
            {
                spawnerItems[i].transform.position = initialPos[random];
                random++;

                if (random == spawnerItems.Count) //pendiente de cambir
                    random = 0;
                
            }
        }

    }



}
