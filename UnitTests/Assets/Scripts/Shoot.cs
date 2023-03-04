using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCoolDown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }
    private void Throw()
    {
        readyToThrow = false;

        //instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow,attackPoint.position,cam.rotation);

        //get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd,ForceMode.Impulse);

        totalThrows--;

        //implement throw Cooldown
        Invoke(nameof(ResetThrow),throwCoolDown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
