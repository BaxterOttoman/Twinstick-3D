using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    void OnCollisionEnter()
    {
        Destroy(gameObject, 2f);
    }

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 60f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
