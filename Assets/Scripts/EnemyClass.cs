using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyClass : NPCClass {
    private static int score = 0;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }

    public override void Die()
    {
        base.Die();

        //Realistically, this should be handled at another level but I'm feeling lazy
        GameObject text = GameObject.FindGameObjectWithTag("Score");
        Text scoreText = text.GetComponent<Text>();
        scoreText.text = "" + (++score);
    }

    public override void MoveAction()
    {
        base.MoveAction();
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if((playerPosition - gameObject.transform.position).magnitude < 1.0f)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterClass>().Die();
        }
    }
}
