using System.Collections;
using UnityEngine;
using Common;
using Common.Audio;
using Utilites;

namespace MainCharacter.States
{
    public class AttackState : PlayerState
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
            _transform = player.transform;
            _attackPoint = player.AttackPoint;
            _attackRadius = player.AttackRadius;
            _attackDelay = player.AttackDelay;
            _punchDelay = player.PunchDelay;
            _attackDamage = player.attackDamage;
            
            _monoBehaviour = _transform.GetComponent<MonoBehaviour>();

        }

        public override void EnterState()
        {
            base.EnterState();
            _attackCoroutine = _monoBehaviour.StartCoroutine(Attack());
        }

        
        

        public override void Process()
        {
            
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
            player.animator.Play("Attack");
            yield return  new  WaitForSeconds(_punchDelay);
            
            AudioController.Instance.Play(Utils.AttackSound);
            
            Punch();
            yield return  new  WaitForSeconds(_attackDelay);
        }
        
        
        
        
        
        

        

       
    }
}