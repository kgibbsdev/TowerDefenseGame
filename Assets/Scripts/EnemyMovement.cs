using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject gameManager;
    public int waypointIndex;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;

        gameManager = GameObject.Find("Gamemanager");

        if(gameManager == null)
        {
            throw new System.Exception("Game Manager not found!");
        }

       target = gameManager.GetComponent<WaypointsManager>().Waypoints[waypointIndex].transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;

        transform.Translate(dir * speed * Time.deltaTime, Space.Self);
        
        if(Vector3.Distance(transform.position, target.position) > 0.4f)
        {
            if(waypointIndex != gameManager.GetComponent<WaypointsManager>().Waypoints.Length - 1)
            {
                waypointIndex++;
                target = gameManager.GetComponent<WaypointsManager>().Waypoints[waypointIndex].transform;
            }
            else
            {
                Destroy(gameObject);
            }
           
        }

    }
}
