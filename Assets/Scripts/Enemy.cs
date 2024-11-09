using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy Died");
            Destroy(this.gameObject,0.05f);
            Destroy(gameObject);
        }
    }

    //add enemy patrol movement
}
