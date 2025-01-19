using System;
using System.Collections.Generic;

namespace PixelSurvivor
{
    public class FSM
    {
        private FsmState _stateCurrent { get; set; }
        
        private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

        public void AddState(FsmState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : FsmState
        {
            var type = typeof(T);

            if (_stateCurrent.GetType() == type)
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                _stateCurrent?.Exit();

                _stateCurrent = newState;
                
                _stateCurrent.Enter();
            }
        }

        public void Update()
        {
            _stateCurrent?.Update();
        }
    }
}