using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject goal1;
    [SerializeField] private GameObject goal2;
    [SerializeField] private float distanceCutoff;
    // Start is called before the first frame update
    void Start()
    {
        goal = goal1;
        distanceCutoff = 0.01f;
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, goal.transform.position);

        if (distance >= distanceCutoff)
        {
            Vector2 direction = (goal.transform.position - transform.position).normalized;
            Vector2 position = transform.position;
            position.x = position.x + (direction.x * speed * Time.deltaTime);
            position.y = position.y + (direction.y * speed * Time.deltaTime);
            transform.position = position;
        }
        else
        {
            goal = goal2;
        }
    }
}
/*speedX = 0f;
        speedY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            speedY = 1f;
        }if (Input.GetKey(KeyCode.S))
        {
            speedY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedX = 1f;
        }*/