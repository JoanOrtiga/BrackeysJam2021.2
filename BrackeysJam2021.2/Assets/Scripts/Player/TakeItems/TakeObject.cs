using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeObject : MonoBehaviour
{
    ///////////////////////////////////////*NO BORRAR LO QUE HAY COMENTADO POR SI
    ////////////////////////////////////// * ACASO TOCA RECUPERARLO
    ////////////////////////////////////// * GRASIAS
    ////////////////////////////////////// */

    //public GameObject InspectorObject;
    private GameObject temporal;
    [SerializeField]
    private float increment =0.2f;
    [SerializeField]
    private float speed = 4f;

    //throw
    private bool isHolding = false;
    private Transform player;
    public Transform PlayerLook;

    private Rigidbody rgb;

    //show name
    public TMP_Text nameIngredient;

    //effect potion
    [SerializeField]
    private float power = 1f;
    public Camera camera;

    private void OnEnable()
    {
        ExamineObject.DelegateTakeObject += ShowObject;
        Strength.delegateStrong += GetPower;
    }
    private void OnDisable()
    {
        ExamineObject.DelegateTakeObject -= ShowObject;
        Strength.delegateStrong -= GetPower;
    }
    private void Start()
    {
        //InspectorObject.gameObject.SetActive(false);
        player = GetComponent<Transform>();
        nameIngredient.text = "";
    }
    private void GetPower(float temporalValue)
    {
        power = temporalValue;
    }
    private void Update()
    {
        if (ModeManager.Instance.currentMode == ModeManager.Modes.InspectorMode)
        {
            //if (Input.GetMouseButton(1) && isHolding)
            //{
            //    ThrowObject();
            //}
            //else if (Input.GetMouseButtonUp(1))
            //{
            //    isHolding = false;

            //    rgb.AddRelativeForce(camera.transform.forward * power, ForceMode.Impulse);

            //    nameIngredient.text = "";

            //    ModeManager.Instance.currentMode = ModeManager.modes.NormalMode;
            //    StartCoroutine(ModeManager.Instance.Switch());
            //}


            if (temporal == null)
            {
                isHolding = false;
                StartCoroutine(AjustChangeMode());
            }

            if (isHolding)
            {
                ThrowObject();

                if (Input.GetMouseButtonDown(0))
                {
                    isHolding = false;
                    rgb.isKinematic = false;
                    rgb.AddForce(camera.transform.forward * power, ForceMode.Impulse);

                    StartCoroutine(AjustChangeMode()); //hacía conflicto con el modo cambiaba (antes de tiempo por lo que tirabas y cogias en 0.000001 segundos.)
                }
            }
        }
    }


    private IEnumerator AjustChangeMode()
    {
        nameIngredient.text = "";

        yield return new WaitForSeconds(0.5f);

        ModeManager.Instance.currentMode = ModeManager.Modes.NormalMode;
        StartCoroutine(ModeManager.Instance.Switch());
    }
    private void ShowObject(GameObject selected)
    {
        if (!isHolding)
        {
            temporal = selected;

            //Cacheamos el getcomponent pork es más óptimo.
            SpawnerItem spawnerItem = temporal.GetComponent<SpawnerItem>();
            
            if (spawnerItem != null)
            {
                temporal = spawnerItem.Spawn();
            }
            
            UpdateTheInspector();
        }
    }

    
    private void UpdateTheInspector()
    {
        //InspectorObject.gameObject.SetActive(true);
        //InspectorObject.GetComponent<MeshFilter>().mesh = temporal.GetComponent<MeshFilter>().mesh;
        //temporal.gameObject.SetActive(false);

        rgb = temporal.GetComponent<Rigidbody>();
        //temporal.transform.position = InspectorObject.transform.position;

        nameIngredient.text = temporal.GetComponent<Catchable>().Name;
        isHolding = true;
        rgb.isKinematic = true;
    }

    private void ThrowObject()
    {
        // InspectorObject.gameObject.SetActive(false);
        rgb.rotation = transform.rotation;
        //rgb.MovePosition(Vector3.Lerp(rgb.position, PlayerLook.position,  speed * Time.deltaTime));
        //temporal.gameObject.SetActive(true);

        rgb.position = Vector3.Lerp(rgb.position, PlayerLook.position, speed * Time.deltaTime);
        //rgb.velocity = (PlayerLook.position - rgb.position) * speed *Time.deltaTime;
    }
}
