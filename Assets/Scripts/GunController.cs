using UnityEngine;


//Controls the player's gun, handling shooting and reloading.

public class GunController : MonoBehaviour
{
    [Header("Gun Settings")]
    public int damage = 10;        //Damage dealt per shot
    public float range = 100f;     //Shooting range
    public int maxBullets = 32;    //Maximum bullets per magazine
    public float fireRate = 0.1f;  //Time between shots

    [Header("References")]
    public Camera fpsCamera;     //Reference to the player's camera

    private int currentBullets;     //Current bullets in the magazine
    private float nextTimeToFire = 0f; //Time until the next shot can be fired

    void Start()
    {
        currentBullets = maxBullets; //Initialize bullets
    }

    void Update()
    {
        HandleShooting();
        HandleReloading();
    }

    //Handles the shooting logic.
    void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentBullets > 0)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    //Handles the reloading logic.
    void HandleReloading()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    //Executes the shooting action.
    void Shoot()
    {
        currentBullets--;
        Debug.Log($"Shooting! Bullets left: {currentBullets}");

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log($"Hit: {hit.transform.name}");

            //Apply damage if the target has an EnemyHealth component
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    ///Reloads the gun.
    void Reload()
    {
        currentBullets = maxBullets;
        Debug.Log("Reloaded!");
    }
}

