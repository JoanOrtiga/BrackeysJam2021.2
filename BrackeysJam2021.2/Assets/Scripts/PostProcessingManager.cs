using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingManager : MonoBehaviour
{
    public GameObject PostProcessingRoseFragrance;

    private void OnEnable()
    {
        RoseFragrance.delegateRoseFragrance += SetRoseFragrance;
    }

    private void OnDisable()
    {
        RoseFragrance.delegateRoseFragrance -= SetRoseFragrance;
    }
    private void SetRoseFragrance(bool state)
    {
        PostProcessingRoseFragrance.SetActive(state);
    }


}
