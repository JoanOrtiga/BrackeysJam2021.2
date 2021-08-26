using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(objectToSpawn, new Vector3(transform.position.x, transform.position.y)
                    , Quaternion.identity, parent.transform);
            }
        }
    }
}
