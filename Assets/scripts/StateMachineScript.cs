using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    Wander,
    Stop,
    Chase,
    ReverseWander
}
public class StateMachineScript : MonoBehaviour
{
    public State state;
    private SpriteRenderer sprite = null;
    public WaypointAI waypointAI = null;
    private GameObject player;
    public float chaseDistance = 1f;
    private IEnumerator WanderState()
    {
        Debug.Log("Wander: Enter");
        sprite.color = Color.green;
        waypointAI.isAIMoving = true;
        while (state == State.Wander)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < chaseDistance && player.activeSelf == true)
            {
                state = State.Chase;
            }
            yield return null;
        }
        Debug.Log("Wander: Exit");
        NextState();
    }
    private IEnumerator ReverseWanderState()
    {
        Debug.Log("Reverse Wander: Enter");
        sprite.color = Color.blue;
        waypointAI.isAIMoving = true;
        while (state == State.ReverseWander)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (player.activeSelf)
            {
                state = State.Wander;
            }
            yield return null;
        }
        Debug.Log("Reverse Wander: Exit");
        NextState();
    }
    private IEnumerator StopState()
    {
        float startTime = Time.time;
        float waitTime = 3f;
        Debug.Log("Stop: Enter");
        sprite.color = Color.red;
        waypointAI.isAIMoving = false;
        while (state == State.Stop)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (Time.time > startTime + waitTime)
            {
                state = State.Wander;
            }
            else if (distance < chaseDistance)
            {
                state = State.Chase;
            }
            yield return null;
        }
        waypointAI.isAIMoving = true;
        Debug.Log("Stop: Exit");
        NextState();
    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        sprite.color = new Color(1, 0, 1, 1);
        while (state == State.Chase)
        {
            waypointAI.target = player;
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < waypointAI.speed * Time.deltaTime)
            {
                player.SetActive(false);
                state = State.ReverseWander;
            }
            if (distance > chaseDistance)
            {
                state = State.Stop;
            }
            yield return null;
        }
        waypointAI.target = null;
        Debug.Log("Chase: Exit");
        NextState();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null)
        {

        }
        Player playerFound = FindObjectOfType<Player>();
        if (playerFound != null)
        {
            player = playerFound.gameObject;
        }
        NextState();
    }
    private void NextState()
    {
        switch (state)
        {
            case State.Wander:
                StartCoroutine(WanderState());
                break;
            case State.Stop:
                StartCoroutine(StopState());
                break;
            case State.Chase:
                StartCoroutine(ChaseState());
                break;
            case State.ReverseWander:
                StartCoroutine(ReverseWanderState());
                break;
            default:
                StartCoroutine(StopState());
                break;
        }
        WanderState();
    }
}
