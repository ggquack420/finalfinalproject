using UnityEngine;

//Handles collision events and related behavior.

public class Collisions : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Placeholder for collision handling logic
        Debug.Log($"Collided with: {collision.gameObject.name}");
    }
}
