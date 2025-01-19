namespace PixelSurvivor
{
    public abstract class FsmState
    {
        protected readonly FSM FSM;

        public FsmState(FSM FSM)
        {
            FSM = this.FSM;
        }
        
        public virtual void Enter() {}
        public virtual void Exit() {}
        public virtual void Update() {}
    }
}