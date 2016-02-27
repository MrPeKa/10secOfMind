using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour { 

    public Texture2D cursorTexture;
    public TxtMsg text;
    public ArrayList ClickObjects;
    public bool ccEnabled = false;
    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        Invoke("SetCustomCursor", 2.0f);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(ray, out hit, 123.123f, 1 << 8)) //8 layers is avaible
        {
            text.ShowText("SFERA");
            if (Input.GetButton("Fire1"))
            {

            }
        }

    }
    void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        ccEnabled = false;
    }

    private void SetCustomCursor()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        Debug.Log("Custom cursor has been set.");
        ccEnabled = true;
    }
}

