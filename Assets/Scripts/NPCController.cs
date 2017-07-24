﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    public List<GameObject> NPCs = new List<GameObject>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnNPCs();
        MoveNPCs();
    }

    private void SpawnNPCs()
    {
        foreach(GameObject npc in NPCs)
        {
            NPCClass npcClass = npc.GetComponent<NPCClass>();
            if(npcClass == null)
            {
                return; //DEVOURED BY TAE
            }
            npcClass.SpawnAction();
        }
    }

    private void MoveNPCs()
    {
        foreach (GameObject npc in NPCs)
        {
            NPCClass npcClass = npc.GetComponent<NPCClass>();
            if (npcClass == null)
            {
                return; //DEVOURED BY TAE
            }
            npcClass.MoveAction();
        }
    }
}