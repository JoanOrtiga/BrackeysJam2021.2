using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject toHide;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);

            if (pauseCanvas.activeSelf)
            {
                Time.timeScale = 0;
                toHide.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
