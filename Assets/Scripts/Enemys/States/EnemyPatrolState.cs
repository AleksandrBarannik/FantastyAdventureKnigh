using System.Collections;
using UnityEngine;

namespace World.Enemy.Scripts.States
{
    public class EnemyPatrolState : EnemyState
    {
        private Transform transform;
        private Rigidbody2D _rigidbody;
        private Vector3[] _path;
        private Vector3 _currentTarget;

        private float _speedMovement;
        public override void Initialize()
        {
            base.Initialize();
            transform = enemy.transform;
            _speedMovement = enemy.SpeedMovement;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
            _path = enemy.Path;
            _currentTarget = _path[Random.Range(0, _path.Length)];
        }

        public override void Process()
        {
            Move();
            CheckDirection();
            enemy.CheckSide(_currentTarget);
           // Debug.Log("Patrol state proces!");
        }

        private void DestroySelf()
        {
        }
        
        
        private void Move()
        {
            Vector3 direction = Vector2.MoveTowards(
                transform.position, _currentTarget, 
                _speedMovement * Time.deltaTime);
            
            _rigidbody.MovePosition(direction);
        }
  
   
        private void CheckDirection()
        {
            if (transform.position != _currentTarget) return;
            ChangeTarget();
            enemy.SetState(endEnemyState);
        }

        private void ChangeTarget()
        {
            
            int index = Random.Range(0, _path.Length);
            _currentTarget = _path[index];
        }

        
        
        
    }
}
