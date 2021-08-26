using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExamineObject : MonoBehaviour
{
    public Camera camera;
    private Transform player;
    private GameObject objectSelected;

    private float maxDistance = 2.5f;

    public delegate void ModeInspector(GameObject itemSelected);
    public static ModeInspector DelegateTakeObject;
    private void Start()
    {
        player = GetComponent<Transform>();

        Physics.IgnoreLayerCollision(9, 9);
    }
    private void Update()
    {
        if (ModeManager.Instance.currentMode != ModeManager.modes.InspectorMode && Input.GetMouseButtonDown(0) && isAInterestingObject())
        {
            ModeManager.Instance.currentMode = ModeManager.modes.InspectorMode;
            StartCoroutine(ModeManager.Instance.Switch());
            DelegateTakeObject?.Invoke(objectSelected);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsAnInteractableObject();
        }
    }

    private bool IsNearToCatch(Vector3 position)
    {
        float distance = Vector3.Distance(player.transform.position, position);

        return distance < maxDistance;
    }

    private bool isAInterestingObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.collider.tag == "Interesting" && IsNearToCatch(hit.transform.position))
            {
                objectSelected = hit.transform.gameObject;
                return true;
            }
        }
        return false;
    }

    private void IsAnInteractableObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.collider.tag == "Interactable" && IsNearToCatch(hit.transform.position))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
