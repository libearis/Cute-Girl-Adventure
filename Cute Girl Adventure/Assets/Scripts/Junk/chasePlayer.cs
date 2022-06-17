using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : StateMachineBehaviour
{
    [SerializeField] float speed = 3f;
    Transform playerPosition;
    Croc crocodileScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        crocodileScript = animator.GetComponent<Croc>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crocodileScript.lookAtPlayer();
        Vector2 targetPosition = new Vector2(playerPosition.position.x, animator.transform.position.y);
        animator.transform.position =  Vector2.MoveTowards(animator.transform.position, targetPosition, speed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
