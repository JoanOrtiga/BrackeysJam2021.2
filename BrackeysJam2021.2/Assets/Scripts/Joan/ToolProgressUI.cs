using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChaosAlchemy
{
    public class ToolProgressUI : MonoBehaviour
    {
        private Transform mainCameraTransform;
        [SerializeField] private Image _image;

        private void Awake()
        {
            mainCameraTransform = Camera.main.transform;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            transform.LookAt(mainCameraTransform);
        }

        public void UpdateProgress(float percentatge)
        {
            _image.fillAmount = percentatge;
        }

        public void ShowStatus(bool status)
        {
            gameObject.SetActive(status);
        }
    }
}

