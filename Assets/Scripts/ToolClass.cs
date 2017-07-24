using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolClass : MonoBehaviour
{
    public ProjectileClass Projectile;
    public float Delay = .1f;
    private Transform shootpoint;
    private float lastUse;

    // Use this for initialization
    void Start ()
    {
        shootpoint = transform.Find("BulletHole");
    }
	
	// Update is called once per frame
	void Update () {
        if (lastUse > 0) lastUse -= Time.deltaTime;
	}

    public void Use()
    {
        if (lastUse <= 0)
        {
            Shoot();
            lastUse = Delay;
        }
    }

    private void Shoot()
    {
        Instantiate(Projectile, shootpoint.transform.position, shootpoint.transform.rotation);
    }
}
