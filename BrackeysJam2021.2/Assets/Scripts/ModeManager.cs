using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance;

    public enum Modes
    {
        NormalMode,
        InspectorMode
    }

    public Modes currentMode;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentMode = Modes.NormalMode;
        Cursor.visible = false;
    }

    private void Update()
    {
        //print(currentMode);
    }

    public IEnumerator Switch()
    {
        yield return new WaitForSeconds(0.5f);

        switch (currentMode)
        {
            case Modes.NormalMode:
                break;
            case Modes.InspectorMode:
                Inspector();
                break;
        }
    }
    private void Inspector()
    { //por el momento nada

        Cursor.visible = false;
    }
}
