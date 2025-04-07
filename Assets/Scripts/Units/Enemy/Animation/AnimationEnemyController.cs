using System.Collections;
using System.Collections.Generic;
using PixelSurvivor;
using UnityEngine;

public class AnimationEnemyController : StateMachineBehaviour
{
    private EnemyController _enemyController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyController = animator.GetComponent<EnemyController>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyController.Move();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }
}
