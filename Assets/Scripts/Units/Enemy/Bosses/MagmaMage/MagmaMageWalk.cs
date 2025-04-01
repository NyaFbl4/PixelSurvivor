using PixelSurvivor;
using UnityEngine;

public class MagmaMageWalk : StateMachineBehaviour
{
    private MagmaMageController _magmaMageController; 

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Enter MagmaMageWalk");
        
        _magmaMageController = animator.GetComponent<MagmaMageController>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _magmaMageController.Move();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exit MagmaMageWalk");

    }
}
