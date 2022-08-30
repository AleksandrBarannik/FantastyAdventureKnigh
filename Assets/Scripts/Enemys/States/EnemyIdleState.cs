using UnityEngine;
using System.Collections;

namespace Enemys.States
{
    public class EnemyIdleState : EnemyState
    {
        private float _timeIdle;
        private Transform _transform;
        

        public override void Initialize()
        {
            base.Initialize();
            _transform = enemy.transform;
           _timeIdle = enemy.TimeIdle;
           
        }

        public override void EnterState()
        {
            base.EnterState();
            
            enemy.StartCoroutine(DoNothingForTime());
        }

        public override void Process()
        {
            if (!IsFinished) return;
            enemy.SetState(endEnemyState);
            
        }

        private IEnumerator DoNothingForTime()
        {
            yield return new WaitForSeconds(_timeIdle);
            IsFinished = true;
          
        }
    }
}