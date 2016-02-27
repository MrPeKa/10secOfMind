using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public MainController target;
    public Player player;
    public float speed;
   

	// Use this for initialization
	void Start () {
      //  Vector3 targetPosition = new Vector3(target.transform.position.x*speed + 5,target.transform.position.y*speed + 5, target.transform.position.z + 5);
    }
	
	// Update is called once per frame
	void Update () {
        if (!player.lockScreen)
        {
            transform.position = new Vector3(target.move.transform.position.x - 5, target.move.transform.position.y * speed + 5.5f, target.move.transform.position.z - 5);
        }
	
	}
}
