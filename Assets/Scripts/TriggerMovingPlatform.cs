using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float platformSpeed = 2.5f;
    private int currentWaypointIndex = 0;
    private bool isActive = false;

    // Update is called once per frame
    private void Update()
    {
        if (isActive)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * platformSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }
}
