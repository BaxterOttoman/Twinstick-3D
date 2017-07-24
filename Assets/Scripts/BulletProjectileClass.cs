using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectileClass : ProjectileClass
{
    public float FireForce;
    public float DefaultLifespan = 60f;
    public float OnHitLifespan = 2f;

    void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.tag == "Enemy") {
            collison.gameObject.GetComponent<NPCClass>().Die();
        }
        Destroy(gameObject, OnHitLifespan);
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * FireForce, ForceMode.Impulse);
        Destroy(gameObject, DefaultLifespan);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
