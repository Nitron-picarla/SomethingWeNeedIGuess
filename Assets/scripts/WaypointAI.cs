using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] goal;
    private int goalIndex = 0;
    private GameObject currentGoal;
    // Start is called before the first frame update
    void Start()
    {
        currentGoal = goal[goalIndex];
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, currentGoal.transform.position);

        if (distance >= 0.01f)
        {
            Vector2 direction = (currentGoal.transform.position - transform.position).normalized;
            Vector2 position = transform.position;
            position.x = position.x + (direction.x * speed * Time.deltaTime);
            position.y = position.y + (direction.y * speed * Time.deltaTime);
            transform.position = position;
        }
        else if (goalIndex < goal.Length)
        {
            goalIndex++;
            currentGoal = goal[goalIndex];
        }
        else
        {
            goalIndex = 0;
            currentGoal = goal[goalIndex];
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