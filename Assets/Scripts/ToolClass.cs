using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolClass : MonoBehaviour
{
    public GameObject Projectile;
    private Transform shootpoint;

    // Use this for initialization
    void Start ()
    {
        shootpoint = transform.Find("BulletHole");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use()
    {
        Instantiate(Projectile, shootpoint.transform.position, shootpoint.transform.rotation).GetComponent<Rigidbody>().AddForce(shootpoint.forward * 50, ForceMode.Impulse);
    }
}
