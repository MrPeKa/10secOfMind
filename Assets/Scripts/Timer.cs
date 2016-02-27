using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public TxtMsg text;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (text.show && text.duration<5)
        {
            text.duration += Time.deltaTime;
        }
        if(text.duration>5 && text.show)
        {
            text.gameObject.GetComponent<GUIText>().enabled = !text.gameObject.GetComponent<GUIText>().enabled;
            text.show = false;
        }
        
	}

}
