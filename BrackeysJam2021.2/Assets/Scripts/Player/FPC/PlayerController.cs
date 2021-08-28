using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    float _cameraPitch = 0.0f;
    float _velocityY = 0.0f;
    CharacterController _controller = null;

    Vector2 _currentDir = Vector2.zero;
    Vector2 _currentDirVelocity = Vector2.zero;

    Vector2 _currentMouseDelta = Vector2.zero;
    Vector2 _currentMouseDeltaVelocity = Vector2.zero;

    public static bool cursorLocked = true;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if(cursorLocked)
        {
           CursorLock();
        }
    }

    void Update()
    {
        if (!(Time.timeScale <= 0.01f))
        {
            UpdateMouseLook();
            UpdateMovement();
        }
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetMouseDelta, ref _currentMouseDeltaVelocity, mouseSmoothTime);

        _cameraPitch -= _currentMouseDelta.y * mouseSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
        transform.Rotate(Vector3.up * (_currentMouseDelta.x * mouseSensitivity));
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, moveSmoothTime);

        if(_controller.isGrounded)
            _velocityY = 0.0f;

        _velocityY += gravity * Time.deltaTime;
		
        Vector3 velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x) * walkSpeed + Vector3.up * _velocityY;

        _controller.Move(velocity * Time.deltaTime);
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
    
    /*
    private float x;
    private float z;
    
    [SerializeField]
    private float speed = 10f;

    private Vector3 move;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementData();
    }
    private void MovementData()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = (transform.right * x + transform.forward * z).normalized;
        rigidbody.velocity = move * speed * Time.deltaTime;
    }
    */
}
