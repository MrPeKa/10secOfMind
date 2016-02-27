using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public TxtMsg text;
    public float effect;
    GameObject txt;

    // Use this for initialization
    void Start()
    {
        txt = GameObject.Find("Text");
    }
	// Update is called once per frame
	void Update () {

        if (text.show && text._currentDuration > 0)
        {
            text._currentDuration -= Time.deltaTime;
        }
        if(text._currentDuration <= 0 && text.show)
        {
                txt.GetComponent<Text>().enabled = !txt.GetComponent<Text>().enabled;
            text.show = false;
            text._currentDuration = text.duration;
        }

        if (effect < 10)
        {
            effect += Time.deltaTime;
            //TODO effects

        }
        else
        {
            effect = 0;
        }

	}

}
