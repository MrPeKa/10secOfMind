using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;

    public int spinSpeed = 100;

    private RotationDirection rotationDirection = RotationDirection.NONE;

    void Start()
    {

    }

    void Update()
    {
        CheckInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(speed);
        Rotate();
    }

    void Move(float speed)
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        var oldVelocity = rb.velocity;
        var newVelocity = new Vector3
        {
            x = (horizontalAxis != 0) ? horizontalAxis * speed : oldVelocity.x,
            y = oldVelocity.y,
            z = (verticalAxis != 0) ? verticalAxis * speed : oldVelocity.z
        };
        rb.velocity = newVelocity;
    }

    void AttachMove(Rigidbody person)
    {
        rb = person.GetComponent<Rigidbody>();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.V))
            rotationDirection = RotationDirection.LEFT;
        else if (Input.GetKey(KeyCode.B))
            rotationDirection = RotationDirection.RIGHT;
        else
            rotationDirection = RotationDirection.NONE;
    }

    private void Rotate()
    {
        switch(rotationDirection)
        {
            case RotationDirection.LEFT:
                rb.transform.Rotate(Vector3.up, spinSpeed);
                break;
            case RotationDirection.RIGHT:
                rb.transform.Rotate(Vector3.down, spinSpeed);
                break;
        }
    }
}

enum RotationDirection
{
    NONE, LEFT, RIGHT
}