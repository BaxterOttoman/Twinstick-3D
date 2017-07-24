using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : NPCClass {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public override void MoveAction()
    {
        base.MoveAction();
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if((playerPosition - gameObject.transform.position).magnitude < 1.0f)
        {
            GameObject deathText = GameObject.FindGameObjectWithTag("DeathText");
            deathText.transform.position = deathText.transform.position + new Vector3(1000f, 0f, 0f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterClass>().Die();
        }
    }
}
