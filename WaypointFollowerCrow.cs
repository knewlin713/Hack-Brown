using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerCrow : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currWaypointIndex = 0;
    private SpriteRenderer crowSprite;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
        crowSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currWaypointIndex].transform.position,
            transform.position) < .1f)
        {
            currWaypointIndex++;
            if (currWaypointIndex >= waypoints.Length)
            {
                currWaypointIndex = 0;
            }
            if (currWaypointIndex%2 == 0)
            {
                crowSprite.flipX = false;
            }
            if (currWaypointIndex % 2 != 0)
            {
                crowSprite.flipX = true;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currWaypointIndex].transform.position,
            Time.deltaTime * speed);
    }
}
