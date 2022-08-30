using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace Enemys.States
{
    
    public class EnemyContusionState : EnemyState
    {
        private Transform _transform;
        private MonoBehaviour _monoBehaviour;
        private Coroutine _HurtCoroutine;
        private float _hurtTime;
        

        public override void Initialize()
        {
            _transform = enemy.transform;
            _monoBehaviour = _transform.GetComponent<MonoBehaviour>();
            _hurtTime = enemy.HurtTime;
            base.Initialize();
        }

        public override void Process()
        {
            
            
        }

        public override void EnterState()
        {
            base.EnterState();
            _HurtCoroutine = _monoBehaviour.StartCoroutine(Hurt());
        }

       
        IEnumerator Hurt()
        {
            enemy.PlayAnimation("Hurt");
            yield return new WaitForSeconds(_hurtTime);
            FinishState();
           
            
        }
        
    }
}
