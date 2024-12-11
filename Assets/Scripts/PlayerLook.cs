using UnityEngine;

//Handles player's look direction based on mouse input.
public class PlayerLook : MonoBehaviour
{
    [Header("Camera Settings")]
    public Camera cam; //Reference to the player's camera

    private float xRotation = 0f;      //Tracks vertical rotation
    public float xSensitivity = 30f;   //Sensitivity for horizontal movement
    public float ySensitivity = 80f;   //Sensitivity for vertical movement

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessLook(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    //Updates camera and player rotation based on mouse input
    public void ProcessLook(float mouseX, float mouseY)
    {
        xRotation -= mouseY * ySensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX * xSensitivity * Time.deltaTime);
    }
}
