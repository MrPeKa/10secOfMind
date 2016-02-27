using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
    public GameObject move;
	
	void Start () {
	    move = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown(KeyCode.N))
        {
            changeMove("Player");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            changeMove("NPC");
        }
    }

    void changeMove(string objectName)
    {
        move = GameObject.Find(objectName).transform.FindChild("body").gameObject;
        move.GetComponent<Movement>().enabled = !move.GetComponent<Movement>().enabled;
    }
}
