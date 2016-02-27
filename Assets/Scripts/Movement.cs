using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    public Transform player;

    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move(speed);
    }

    void Move(float speed)
    {
        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
   //         player.rotation = Quaternion.Slerp(transform.rotation, Mathf.Sign(Input.GetAxis("Horizontal")) * 90, Time.deltaTime);

            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            rotation *= Quaternion.Euler(0, 90, 0); // this add a 90 degrees Y rotation
            player.rotation = Quaternion.Slerp(player.rotation, rotation, Time.deltaTime * 10);


        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void AttachMove(Rigidbody person)
    {
        rb = person.GetComponent<Rigidbody>();
    }


}
