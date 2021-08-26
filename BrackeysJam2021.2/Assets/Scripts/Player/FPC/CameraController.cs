using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public GameObject Inspector;
    private float x;
    private float y;

    private float minLimit = -60f;
    private float maxLimit = 60f;

    private float speed = 500f;

    private float rotationX;

    private static bool cursorLocked;
    void Start()
    {
        CursorLock();
    }
    void Update()
    {
        if (cursorLocked)
            CameraMovement();
    }

    private void OnEnable()
    {
        MouseInvertEffect.DelegateMouseInvert += GetInvert;
    }

    private void OnDisable()
    {
        MouseInvertEffect.DelegateMouseInvert -= GetInvert;
    }

    private void GetInvert(bool invert)
    {
        if (invert)
            speed = speed * -1;
        else
            speed = 500f;
    }

    private void CameraMovement()
    {


        x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        rotationX -= y;
        rotationX = Mathf.Clamp(rotationX, minLimit, maxLimit);

        this.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        player.Rotate(Vector3.up, x);
    }
    public static void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
    }
    public static void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }
}
