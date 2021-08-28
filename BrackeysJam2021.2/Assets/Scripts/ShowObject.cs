using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public GameObject g;
    public void Show()
    {
        g.SetActive(true);
    }
    public void Hide()
    {
        g.SetActive(false);
        Time.timeScale = 1;
    }
}
