using UnityEngine.Events;
using MainCharacter;

namespace MainCharacter.States
{
    public abstract class PlayerState
    {
        public Player player;
        
        
        public readonly UnityEvent onEnterState = new UnityEvent(); 
        public readonly UnityEvent onFinishState = new UnityEvent(); 
        
        public virtual void Initialize() { }
        
        public virtual void EnterState()
        {
            onEnterState.Invoke();
        }

        public virtual void FinishState()
        {
            onFinishState.Invoke();
        }

        public abstract void Process();
    }
}