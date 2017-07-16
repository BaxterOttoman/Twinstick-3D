using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour {
    public bool Grounded;
    public float MovementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Live()
    {

    }

    public void Die()
    {

    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * MovementSpeed * Time.deltaTime, Space.World);

        if (Grounded)
        {
            BeGrounded();
        }
    }

    public void Act(Action action)
    {
        switch (action)
        {
            case Action.Shoot:
                //Shoot();
                break;

            default:
                break;
        }
    }

    private void BeGrounded()
    {
        RaycastHit hit;
        Ray headRay = new Ray(transform.position + Vector3.up, Vector3.down);
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, float.PositiveInfinity, 1 << 8))
        {
            transform.Translate(hit.point + Vector3.up - transform.position);
        }
    }

    public enum Action
    {
        Shoot,
    }
}
