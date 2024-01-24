using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private bool reverse = false;
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) {
            if(reverse) {
                currentWaypointIndex--;
            } else {
                currentWaypointIndex++;
            }

            if(currentWaypointIndex >= waypoints.Length-1) {
                reverse = true;
            } else if(currentWaypointIndex <= 0) {
                reverse = false;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
