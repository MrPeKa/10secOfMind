using UnityEngine;
using System.Collections;
using System;

public class NpcSight : MonoBehaviour {
    const int ONLY_NOT_PLAYER_MASK = ~(1 << 10);

    [SerializeField]
    public GameObject target;

    [SerializeField]
    private int maxDistance;

    private bool spotted = false;

    public Action<GameObject, GameObject> SpottedActionHandler { get; set; }

	// Use this for initialization
	void Start()
    {
        SpottedActionHandler = (s, t) => { Debug.Log(s.name + " spotted " + t.name); };
	}
	
	// Update is called once per frame
	void Update()
    {
	}
    
    void OnTriggerStay(Collider other)
    {
        if (!SpottedActionHandlerPresent())
            return;

        if (other.gameObject != target)
            return;

        var raycastSourcePosition = gameObject.transform.position;
        var spanningVector = other.transform.position - raycastSourcePosition;
        var ray = new Ray(raycastSourcePosition, spanningVector);

        RaycastHit hit;
        var raycastMetTarget = Physics.Raycast(ray, out hit, maxDistance) && (hit.collider.gameObject == target);
        if (raycastMetTarget && !spotted)
        {
            spotted = true;
            SpottedActionHandler.Invoke(gameObject, target);
        }
        else if(!raycastMetTarget && spotted)
        {
            spotted = false;
        }
    }

    private bool SpottedActionHandlerPresent()
    {
        return SpottedActionHandler != null;
    }
}
