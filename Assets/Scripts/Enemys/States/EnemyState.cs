using Enemys;
using UnityEngine.Events;


    public abstract class EnemyState
    {
        public Enemy enemy;
        public EnemyState endEnemyState;
        protected bool IsFinished { get; set; }
        
        public readonly UnityEvent onEnterState = new UnityEvent(); 
        public readonly UnityEvent onFinishState = new UnityEvent(); 
        
        public virtual void Initialize() { }
        
        public virtual void EnterState()
        {
            onEnterState.Invoke();
            IsFinished = false;
        }

        public virtual void FinishState()
        {
            onFinishState.Invoke();
            IsFinished = true;
        }

        public abstract void Process();
    }
