using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject bullet;
    

    [Header("Settings")]
    public int totalShots;
    public float gunCooldown;


    [Header("Gun")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public float shotForce;
    public float shotUpwardForce;

    bool readyToShoot;

    private void Start()
    {
        readyToShoot = true;
    }

    private void Update()
    {
           if(Input.GetKeyDown(shootKey) && readyToShoot && totalShots > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        // instantiate object to shoot
        GameObject projectile = Instantiate(bullet,  attackPoint, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // add force
        Vector3 forceToAdd = cam.transform.forward * shotForce + transform.up * shotUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalShots--;

        // implement shotCooldown
        Invoke(nameof(Resetshot), gunCooldown);
    }

    private void Resetshot()
    {
        readyToShoot = true;

    }
}
