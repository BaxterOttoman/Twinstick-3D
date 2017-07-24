﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass : CharacterClass {
    public Movement MovementType;
    public Spawn SpawnType;

    private const float NEARSPAWNDISTANCE = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void SpawnAction()
    {
        switch(SpawnType)
        {
            case Spawn.NearPlayer:
                SpawnNearPlayer();
                break;
        }
    }

    private void SpawnNearPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return; //They're eating her and then they're going to eat me oh my goooooooooooooooooooooooooooooooooooooooooooooood
        }
        Vector3 position = player.transform.position;
        float relativeX = Random.Range(-1.0f, 1.0f);
        float relativeZ = Random.Range(-1.0f, 1.0f);
        Normalize(ref relativeX, ref relativeZ);
        Debug.Log("X: " + relativeX);
        Debug.Log("X: " + relativeZ);
        position.x = position.x + relativeX;
        position.z = position.z + relativeZ;
        GameObject npc = Instantiate(gameObject, position, new Quaternion());

        NPCClass npcClass = npc.GetComponent<NPCClass>();
        if (npcClass == null)
        {
            return; //DEVOURED BY TAE
        }
        npcClass.BeGrounded();
    }

    private void Normalize(ref float x, ref float y)
    {
        float total = Mathf.Sqrt((x * x) + (y * y));
        float factor = NEARSPAWNDISTANCE / total;
        x = x * factor;
        y = y * factor;

    }

    public void MoveAction()
    {
        switch (MovementType)
        {
            case Movement.RushPlayer:
                RushPlayer();
                break;
        }
    }

    private void RushPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return; //They're eating her and then they're going to eat me oh my goooooooooooooooooooooooooooooooooooooooooooooood
        }
        Vector3 playerPosition = player.transform.position;
        Move(playerPosition - transform.position);
    }
}

public enum Movement
{
    RushPlayer,
    RandomWalk
}

public enum Spawn
{
    NearPlayer,
    FarFromPlayer,
    Random
}