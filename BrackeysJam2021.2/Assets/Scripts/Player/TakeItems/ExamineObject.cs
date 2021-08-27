using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ExamineObject : MonoBehaviour
{
    public Camera mainCamera;
    
    private GameObject _objectSelected;
    private float _maxDistance = 2.5f;
    public delegate void ModeInspector(GameObject itemSelected);
    public static ModeInspector DelegateTakeObject;
    private void Start()
    {
        //Physics.IgnoreLayerCollision(9, 9);
    }
    private void Update()
    {
        if (ModeManager.Instance.currentMode != ModeManager.Modes.InspectorMode && Input.GetMouseButtonDown(0) && IsAInterestingObject())
        {
            ModeManager.Instance.currentMode = ModeManager.Modes.InspectorMode;
            StartCoroutine(ModeManager.Instance.Switch());
            DelegateTakeObject?.Invoke(_objectSelected);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsAnInteractableObject();
        }
    }

    private bool IsAInterestingObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _maxDistance))
        {
            if (hit.collider.CompareTag("Interesting"))
            {
                _objectSelected = hit.transform.gameObject;
                return true;
            }
        }
        return false;
    }

    private void IsAnInteractableObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _maxDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
