using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Handles camera movement based on mouse input for controller.
public class CameraController : MonoBehaviour
{

    public float mouseSensitivity = 2f;

    private float xRotation = 0f; //Tracks vertical rotation (looking up/down)
    private Camera playerCamera;  //Reference to the player's camera

    void Start()
    {
        //Cache the player's camera component
        playerCamera = GetComponentInChildren<Camera>();

        //Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
    }

    //Handles mouse input for camera movement.
    private void HandleMouseLook()
    {
        //Get mouse input for horizontal and vertical movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        //Update and clamp vertical rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Apply vertical rotation to the camera
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

