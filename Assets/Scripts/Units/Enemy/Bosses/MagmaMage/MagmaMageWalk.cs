
using UnityEngine;

public class MagmaMageWalk : StateMachineBehaviour
{
    private Transform _player;

    [SerializeField] private Transform _bossTransform;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Enter MagmaMageWalk");
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            _player = player.transform;
            
            Debug.Log("1");
        }
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToPlayer = Vector2.Distance(_bossTransform.position, _player.position);

        if (distanceToPlayer > _attackRange)
        {
            Vector3 vector3 = (_player.position - _bossTransform.position).normalized;
            
            _bossTransform.position += vector3 * _moveSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("Attack_1");
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exit MagmaMageWalk");
        
        animator.ResetTrigger("Attack_1");
    }
}
