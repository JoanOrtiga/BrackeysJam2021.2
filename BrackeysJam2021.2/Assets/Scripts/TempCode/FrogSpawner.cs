using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    public UnityEngine.GameObject objectToSpawn;
    public UnityEngine.GameObject parent;
    public int numberToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(objectToSpawn, new Vector3(transform.position.x, transform.position.y)
                    , Quaternion.identity, parent.transform);
            }
        }
    }
}
