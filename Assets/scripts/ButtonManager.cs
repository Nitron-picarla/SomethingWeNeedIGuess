using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonManager : MonoBehaviour
{
    public StateMachineScript aiStateMachine;

    private GameObject player;
    private void Start()
    {
        Player playerFound = FindObjectOfType<Player>();
        if (playerFound != null)
        {
            player = playerFound.gameObject;
        }
    }
    public void Wander()
    {
        aiStateMachine.state = State.Wander;
        player.SetActive(true);
    }
    public void Stop()
    {
        aiStateMachine.state = State.Stop;
    }
    public void ReverseWander()
    {
        aiStateMachine.state = State.ReverseWander;
        player.SetActive(false);

    }
    public void Chase()
    {
        aiStateMachine.state = State.Chase;
    }
}
