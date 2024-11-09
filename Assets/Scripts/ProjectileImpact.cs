using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    public GameObject impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiating and destroying impact effects
        if (impactEffect != null)
        {
            //Debug.Log("Entering the Collision Area", collision.gameObject);
            GameObject impact = Instantiate(impactEffect, collision.contacts[0].point, Quaternion.identity);
            Destroy(impact,2f);
           
            //StartCoroutine(DestroyAfterSometime(impact));
        }


        Destroy(gameObject);



    }


     
    //IEnumerator DestroyAfterSometime(GameObject impactEFX)
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    Destroy(impactEFX);
    //    Debug.Log("Impact EFFECT OFF");
    //}
}
