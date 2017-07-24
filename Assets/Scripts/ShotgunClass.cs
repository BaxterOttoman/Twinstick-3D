using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunClass : ToolClass
{
    public ProjectileClass Projectile;
    public int ShotCount = 5;
    public float Delay = .1f;
    private Transform shootpoint;
    private float lastUse;

    // Use this for initialization
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (var c in children)
        {
            if (c.name == "BulletSpawn") shootpoint = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastUse > 0) lastUse -= Time.deltaTime;
    }

    public override void Use()
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
