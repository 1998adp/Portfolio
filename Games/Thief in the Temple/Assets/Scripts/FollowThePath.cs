using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint
    // to the next one
    private int waypointIndex = 0;

    public GameObject background;
    public GameObject platform;
    public float delay;

    // Use this for initialization
    private void Start()
    {

        // Set position current to first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
        StartCoroutine(Delayplatfrom());
    }

    // Update is called once per frame
    private void Update()
    {

        // Move 
        Move();
    }

    private void Awake()
    {

        StartCoroutine(Delayplatfrom());

    }


    private IEnumerator Delayplatfrom()
    {
        background.gameObject.SetActive(false);
        platform.gameObject.SetActive(false);
        waypointIndex += 1;

        yield return new WaitForSeconds(delay);

        background.gameObject.SetActive(true);
        platform.gameObject.SetActive(true);

        yield return new WaitForSeconds(delay / 2);

        if (waypointIndex == waypoints.Length)
        {
            System.Array.Reverse(waypoints);
            waypointIndex = 0;
        }

    }

    // Method that actually mmoves the platform
    private void Move()
    {
        // If it didn't reach last waypoint it can move
        // If it reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1 )
        {

            // Move from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint it goes towards
            // then waypointIndex is increased by 1
            // and it starts to go to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                Awake(); 
            }

        }
        

    }
}