using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public float stopAttackingDistance = 2.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (SoundManager.Instance.ZombieChannel.isPlaying == false)
        {
            SoundManager.Instance.ZombieChannel.PlayOneShot(SoundManager.Instance.zombieAttack);
           
        }


        LookAtPlayer();


        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);


        if (distanceFromPlayer > stopAttackingDistance)
        {
            animator.SetBool("isAttacking", false);
        }

    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position; 
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0, yRotation, 0);

        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.Instance.ZombieChannel.Stop();
    }
}
