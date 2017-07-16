using UnityEngine;
using System.Collections;

public class PlayerController : CharacterClass
{
    public GameObject projectile;
    private Transform shootpoint;
    private Rigidbody rb;
    private Quaternion aimAngle;
    private Vector3 aimPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        shootpoint = transform.Find("BulletHole");
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
            Act(Action.Shoot);

        Plane aimPlane = new Plane(Vector3.up, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (aimPlane.Raycast(ray, out rayDistance))
            aimPoint = ray.GetPoint(rayDistance);

        Debug.DrawLine(aimPoint, aimPoint + Vector3.up);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Move(movement);

        SetAimAngle();
        transform.rotation = aimAngle;
    }

    private void SetAimAngle()
    {
        if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") != 0)
        {
            Plane aimPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (aimPlane.Raycast(ray, out rayDistance))
                aimPoint = ray.GetPoint(rayDistance);

            Debug.DrawLine(transform.position, aimPoint);
            aimAngle = Quaternion.LookRotation(aimPoint - transform.position);
        }

        if (Input.GetAxis("Horizontal2") + Input.GetAxis("Vertical2") != 0)
        {
            aimPoint = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")) + transform.position;
            Debug.DrawLine(transform.position, aimPoint);
            aimAngle = Quaternion.LookRotation(aimPoint - transform.position);
            Act(Action.Shoot);
        }
    }
}