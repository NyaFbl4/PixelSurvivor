using UnityEngine;

namespace PixelSurvivor
{
    public class FsmStateIdle : FsmState
    {
        protected Transform _target;
        
        public FsmStateIdle(FSM FSM, Transform target) : base(FSM)
        {
            _target = target;
        }

        public override void Enter()
        {
            Debug.Log("Idle state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log("Idle state [EXIT]");
        }

        public override void Update()
        {
            Debug.Log("Idle state [Update]");

            if (_target)
            {
                FSM.SetState<FsmStateWalk>();
            }
        }
    }
}