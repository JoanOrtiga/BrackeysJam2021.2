using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpeedTeleport : PotionEffect
{
    [SerializeField]
    private List<SpawnerItem> spawnerItems;
    [SerializeField]
    private Vector3[] initialPos;

    private int random;
    private bool apply;
    private bool runOnce = false;

    private void OnEnable()
    {
        EffectManager.delegateEffectManager += GetApplyValue;
    }

    private void OnDisable()
    {
        EffectManager.delegateEffectManager -= GetApplyValue;
    }
    private void GetApplyValue(bool value)
    {
        apply=value;
    }
    public override void ActivePotionEffect()
    {
        apply = (bool)delegateClock?.Invoke();
    }
    private void Awake()
    {
        spawnerItems = FindObjectsOfType<SpawnerItem>().ToList();
        initialPos = new Vector3[spawnerItems.Count];
    }

    private void Update()
    {
        if (apply)
        {
            if (Mathf.RoundToInt(EffectManager.timer) % 10 == 0 && !runOnce)
            {
                
                runOnce = true;
                TeleportSpawners();
            }
            else if(Mathf.RoundToInt(EffectManager.timer) % 10 > 0)
            {
                runOnce = false;
            }   
        }  
    }

    private void TeleportSpawners()
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
 
}
