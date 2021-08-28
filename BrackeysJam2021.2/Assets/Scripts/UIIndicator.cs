using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIIndicator : MonoBehaviour
{

    private TMP_Text indicator;

    private void Start()
    {
        indicator = GetComponent<TMP_Text>();
    }
    private void OnEnable()
    {
        ExamineObject.delegateShowIndicator += ChangeIndicatorText;
    }

    private void OnDisable()
    {
        ExamineObject.delegateShowIndicator -= ChangeIndicatorText;
    }
    private void ChangeIndicatorText(string newText)
    {
        indicator.text = newText;
    }
}
