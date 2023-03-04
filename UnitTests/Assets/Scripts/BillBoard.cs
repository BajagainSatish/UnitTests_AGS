using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;
    // Update is called once per frame
    void LateUpdate()
    {
        //healthbar always faces our camera
        transform.LookAt(transform.position + cam.forward);
    }
}
