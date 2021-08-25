using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    public GameObject InspectorObject;
    private GameObject temporal;
    private float modif = 100f;
    private float speed = 2f;

    //throw
    private bool isHolding = false;
    private Transform player;
    public Transform PlayerLook;

    private Rigidbody rgb;

    private void OnEnable()
    {
        ExamineObject.DelegateTakeObject += ShowObject;
    }

    private void OnDisable()
    {
        ExamineObject.DelegateTakeObject -= ShowObject;
    }
    private void Update()
    {
        if (ModeManager.Instance.currentMode == ModeManager.modes.InspectorMode)
        {
            if (Input.GetMouseButton(1) && isHolding)
            {
                ThrowObject();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                isHolding = false;

                ModeManager.Instance.currentMode = ModeManager.modes.NormalMode;
                StartCoroutine(ModeManager.Instance.Switch());
            }
        }
    }

    private void Start()
    {
        InspectorObject.gameObject.SetActive(false);
        player = GetComponent<Transform>();
    }
   
    private void ShowObject(GameObject selected)
    {
        if (!isHolding)
        {
            temporal = selected;
            if (temporal.GetComponent<SpawnerItem>())
            {
                GameObject spawned = selected.GetComponent<SpawnerItem>().Spawn();
                temporal = spawned;

                //temporal.name = "obj" + index;
                //index++;

                //ExamineObject.interestingObjects.Add(temporal);

                UpdateTheInspector();

            }
            else
            {
                UpdateTheInspector();
            }
            //Sin el ELSE agarra sin pulsar.
        }
    }

    private void UpdateTheInspector() 
    {
        InspectorObject.gameObject.SetActive(true);
        InspectorObject.GetComponent<MeshFilter>().mesh = temporal.GetComponent<MeshFilter>().mesh;
        temporal.gameObject.SetActive(false);

        rgb = temporal.GetComponent<Rigidbody>();
        temporal.transform.position = InspectorObject.transform.position;
        isHolding = true;
    }

    private void ThrowObject()
    {
        if (isHolding)
        {
            InspectorObject.gameObject.SetActive(false);
            
            rgb.position = Vector3.Lerp(rgb.position, PlayerLook.position, speed * Time.deltaTime);
            temporal.gameObject.SetActive(true);

            rgb.velocity = (PlayerLook.position - rgb.position) * modif * Time.deltaTime;
        }
    }
}
