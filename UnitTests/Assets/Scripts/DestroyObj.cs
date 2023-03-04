using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject); //destroy bullet after 5 sec of being instantiated
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CapsuleEnemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    */
}
