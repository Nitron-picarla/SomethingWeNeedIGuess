using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointAI : MonoBehaviour
{
    public float speed;
    public GameObject[] goal;
    private int goalIndex = 0;
    private GameObject currentGoal;
    public bool isAIMoving = true;
    public GameObject target;
    private GameObject player;
    public StateMachineScript aiStateMachine;

    void Start()
    {
        currentGoal = goal[goalIndex];
        speed = 2;
        Player playerFound = FindObjectOfType<Player>();
        if (playerFound != null)
        {
            player = playerFound.gameObject;
        }
    }
    void Update()
    {
        if (isAIMoving==false)
        {
            return;
        }
        if (target==null)
        {
            Wander(currentGoal, speed);
        }
        else
        {
            Chase(target, speed);
        }
    }
    void Chase(GameObject goal, float currentSpeed)
    {
        Vector2 direction = (goal.transform.position - transform.position).normalized;
        Vector2 position = transform.position;
        position = position + (direction * currentSpeed * Time.deltaTime);
        transform.position = position;
    }
    void Wander(GameObject goal, float currentSpeed)
    {
        float distance = Vector2.Distance(transform.position, currentGoal.transform.position);
        if (distance >= 0.01f)
        {
            Chase(currentGoal, speed);
        }
        else
        {
            if (player.activeSelf)
            {
                NextGoal();
            }
            else
            {
                NextGoalReverse();
            }
            
        }
    }
    void NextGoal()
    {
        goalIndex++;
        if  (goalIndex > (goal.Length - 1))
        {
            goalIndex = 0;
        }
        currentGoal = goal[goalIndex];
    }
    void NextGoalReverse()
    {
        goalIndex--;
        if (goalIndex < 0)
        {
            goalIndex = (goal.Length-1);
        }
        currentGoal = goal[goalIndex];
    }
}