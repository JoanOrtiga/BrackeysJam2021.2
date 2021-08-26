using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public UnityEngine.GameObject Prefab;
    public UnityEngine.GameObject SpaceToSave;


    public UnityEngine.GameObject Spawn()
    {
          return Instantiate(Prefab, transform.position, Quaternion.identity, SpaceToSave.transform);
    }
}
