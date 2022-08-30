using System.Collections;
using Common;
using UnityEngine;

namespace Enemys.States
{
    public class EnemyAttackState : EnemyState
    {
        private Transform _transform;
        private Transform _attackPoint;
        private float _attackRadius;
        private float _attackDelay;
        private float _punchDelay;
        private int _attackDamage;
        
        private MonoBehaviour _monoBehaviour;
        private Coroutine _attackCoroutine;
        
        
        
        
        
        public override void Initialize()
        {
            base.Initialize();
            _transform = enemy.transform;
            _attackPoint = enemy.AttackPoint;
            _attackRadius = enemy.AttackRadius;
            _attackDelay = enemy.AttackDelay;
            _punchDelay = enemy.PunchDelay;
            _attackDamage = enemy.Damage;
            
            _monoBehaviour = _transform.GetComponent<MonoBehaviour>();

        }

        public override void Process()
        {
            enemy.CheckSide(enemy.player.position);
        }
        

        
        public override void EnterState()
        {
            base.EnterState();
            
            _attackCoroutine = _monoBehaviour.StartCoroutine(Attack());
            
        }
        
        public override void FinishState()
        {
            base.FinishState();
            
            _monoBehaviour.StopCoroutine(_attackCoroutine);
        }

        
        private void Punch() //Проверка вокруг всех колайдеров которые имеют здоровье и уменьшение здоровья
        {
            var coliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius);

            foreach (var col in coliders)
            {
                if (col.gameObject == _transform.gameObject) continue;
                if (!col.GetComponent<Health>()) continue;
                col.GetComponent<Health>().DecreaseHealth(_attackDamage);
                
            }

        }

        IEnumerator Attack()
        {
            enemy.PlayAnimation("Attack");
            yield return  new  WaitForSeconds(_punchDelay);
            Punch();
            yield return  new  WaitForSeconds(_attackDelay);
            _attackCoroutine = _monoBehaviour.StartCoroutine(Attack());
        }
        
        
        
        
        
        

        

       
    }
}
