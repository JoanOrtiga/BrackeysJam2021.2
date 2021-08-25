using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExamineObject : MonoBehaviour
{
    public Camera camera;
    public static List<GameObject> interestingObjects;
    public Transform player;
    private GameObject objectSelected;

    private float maxDistance = 2.5f;

    public delegate void ModeInspector(GameObject itemSelected);
    public static ModeInspector DelegateTakeObject;
    private void Start()
    {
        interestingObjects = GameObject.FindGameObjectsWithTag("Interesting").ToList();//TEMPORAL;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && isAInterestingObject())
        {
            ModeManager.Instance.currentMode = ModeManager.modes.InspectorMode;
            StartCoroutine(ModeManager.Instance.Switch());
            DelegateTakeObject?.Invoke(objectSelected);
        }
    }

    private bool IsNearToCatch(string name)
    {
        print(name);
        for (int i = 0; i < interestingObjects.Count; i++)
        {
            if (name == interestingObjects[i].name)
            {
                float distance = Vector3.Distance(player.transform.position, interestingObjects[i].transform.position); 
                if (distance < maxDistance)
                {
                    objectSelected = interestingObjects[i];
                    return true;
                }
            }
        }
        return false;
    }

    private bool isAInterestingObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
        
            if (hit.collider.tag == "Interesting" && IsNearToCatch(hit.collider.name))
                return true;
        }
        return false;

    }
}
