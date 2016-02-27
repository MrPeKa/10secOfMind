using UnityEngine;
using System.Collections;

public class TxtMsg : MonoBehaviour {

    public float duration = 0;
    public bool show = false;
    public string msg = "hello";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && duration<5)
        {
            show = true;
            ShowText();
        }
    }

    void ShowText()
    {
 
            gameObject.transform.position = new Vector3(0.5f, 0.5f, 0.0f);
            gameObject.GetComponent<GUIText>().text = msg;

    }
}
