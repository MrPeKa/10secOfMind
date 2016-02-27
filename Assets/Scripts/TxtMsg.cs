using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TxtMsg : MonoBehaviour {

    public float duration;
    public float _currentDuration;
    public bool show = false;
    public string msg;

    // Use this for initialization
    void Start () {
        _currentDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            ShowText(msg);
        }
    }

    public void ShowText()
    {
        if (_currentDuration > 0)
        {
            show = true;
            GameObject.Find("Text").GetComponent<Text>().enabled = true;
        }
    }
    public void ShowText(string msg)
    {
        if (_currentDuration > 0)
        {
            show = true;
            GameObject.Find("Text").GetComponent<Text>().enabled = true;
            GameObject.Find("Text").GetComponent<Text>().text = msg;
        }
    }
}
