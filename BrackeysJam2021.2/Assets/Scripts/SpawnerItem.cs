using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject SpaceToSave;


    public GameObject Spawn()
    {
          return Instantiate(Prefab, transform.position, Quaternion.identity, SpaceToSave.transform);
    }
}
