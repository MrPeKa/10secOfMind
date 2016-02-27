using UnityEngine;
using System.Collections;

public class FollowWaypoints : MonoBehaviour {

    public Waypoints[] waypoints;
    //public Transform[] way;
    public float speed;
    public float reachDistance = 0.5f;
    public int numberOfWaypoint = 0;
    public int currentPoint = 0;
    public float waitTime;
    public bool distanceReached = false;
    public bool npcControlled = false;
    public float confuseTime;
    public bool confused = false;
    private float confuseTime2;
    //public int currentPointSecondIndex;

    // Use this for initialization
    void Start () {
        //waypoint = new ArrayList();
        waitTime = waypoints[numberOfWaypoint].waypoint[currentPoint].timeInWaypoint;
        confuseTime2 = confuseTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (npcControlled)
        {
            if (Input.GetKey(KeyCode.P))
            {
                waitTime = 0;
                distanceReached = false;
                confused = true;
                npcControlled = false;
            }
        }
        else
        {
            if (confused)
            {
                if (confuseTime > 0.0)
                {
                    confuseTime -= Time.deltaTime;
                }
                else
                {
                    confuseTime = confuseTime2;
                    confused = false;
                    getRandomWaypoint();
                }
            }
            else
            {
                if (waypoints.Length > 0)
                {
                    float dist = Vector3.Distance(waypoints[numberOfWaypoint].waypoint[currentPoint].transform.position, transform.position);
                    if (!distanceReached)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, waypoints[numberOfWaypoint].waypoint[currentPoint].transform.position, Time.deltaTime * speed);
                    }
                    if (dist <= reachDistance)
                    {
                        distanceReached = true;
                        if (waitTime > 0.0)
                        {
                            waitTime -= Time.deltaTime;
                        }
                        else
                        {
                            if ((currentPoint + 1) == waypoints[numberOfWaypoint].waypoint.Length)
                            {
                                getRandomWaypoint();
                            }
                            else
                            {
                                currentPoint = (currentPoint + 1) % waypoints[numberOfWaypoint].waypoint.Length;
                            }
                            waitTime = waypoints[numberOfWaypoint].waypoint[currentPoint].timeInWaypoint;
                            distanceReached = false;
                        }
                    }
                }
            }
        }

    }

    void getRandomWaypoint()
    {
        int random01 = Random.Range(0, waypoints.Length);
        numberOfWaypoint = random01;
        currentPoint = 0;
    }


    /*void OnDrawGizmos()
    {
        if (waypoint.Length > 0)
        {
            for (int i = 0; i < waypoint.Length; i++)
            {
                if (waypoint[i].transform != null)
                {
                    Gizmos.DrawSphere(waypoint[i].transform.position, reachDistance);
                }
            }

        }
    }*/
}
