using UnityEngine;

namespace PixelSurvivor
{
    public class FsmStateMovement : FsmState
    {
        protected readonly Transform _target;
        protected readonly Transform _transform;
        protected readonly float _speed;

        public FsmStateMovement(FSM fsm, Transform target ,Transform transform, float speed) : base(fsm)
        {
            _target = target;
            _transform = transform;
            _speed = speed;
        }

        public override void Enter()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [EXIT]");
        }

        public override void Update()
        {
            base.Update();
        }
    }
}