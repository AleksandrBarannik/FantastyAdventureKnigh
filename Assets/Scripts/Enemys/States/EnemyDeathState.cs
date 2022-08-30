using Common;
using UnityEngine;
namespace Enemys.States
{
    public class EnemyDeathState : EnemyState
    {
        private MonoBehaviour _monoBehaviour;
        private Transform _transform;
        private float _timeDestroy;
        

        public override void Initialize()
        {
            base.Initialize();
            _transform = enemy.transform;
            _timeDestroy = enemy.TimeToDestroy;
            _monoBehaviour = _transform.GetComponent<MonoBehaviour>();
            
        }

        public override void Process()
        {
            
          
        }
        
        
        
        private void DestroySelf()
        {
           GameObject.Destroy(_transform.gameObject,_timeDestroy);
        }
        
        public override void EnterState()
        {
            base.EnterState();
            
            enemy.PlayAnimation("Died");
            DestroySelf();
            FinishState();
            
            
        }
        
       
    }
}
