using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    public IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        Destroy(gameObject); //destroy bullet after 7 sec of being instantiated
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
