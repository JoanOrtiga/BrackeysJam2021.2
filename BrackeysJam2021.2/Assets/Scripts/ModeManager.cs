using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance;

    public enum modes
    {
        NormalMode,
        InspectorMode
    }

    public modes currentMode;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentMode = modes.NormalMode;
        Cursor.visible = false;
    }

    public IEnumerator Switch()
    {
        yield return new WaitForSeconds(0.5f);

        switch (currentMode)
        {
            case modes.NormalMode:
                break;
            case modes.InspectorMode:
                Inspector();
                break;
        }
    }
    private void Inspector()
    { //por el momento nada

        Cursor.visible = false;
    }
}
