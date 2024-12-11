using UnityEngine;

//Handles the player's movement logic

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; //Speed of the player's movement

    void Update()
    {
        HandleMovement();
    }

    //Processes player input and moves the player character
    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
