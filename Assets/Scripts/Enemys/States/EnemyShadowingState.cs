using System.Collections;
using UnityEngine;

namespace World.Enemy.Scripts.States
{
    public class EnemyShadowingState : EnemyState
    {
        private Transform _transform;
        private Vector2 _playerPosition;
        private Rigidbody2D _rigidbody;
        private Transform _player;

        private float _speedMovement;
        public override void Initialize()
        {
            base.Initialize();
            _transform = enemy.transform;
            _speedMovement = enemy.SpeedRun;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
            _player = enemy.player;
        }

        public override void Process()
        {
            Move();
            enemy.CheckSide(_player.position );
          //Debug.Log("Shadowing state proccess...");
        }

        
        
        private void Move()
        {
            
            //Debug.Log("Enter ShadowingState!");
            Vector3 target = new Vector3(_player.position.x, _transform.position.y);
            
            Vector3 direction = Vector2.MoveTowards(
                _transform.position, target , 
                _speedMovement * Time.deltaTime);
            _rigidbody.MovePosition(direction);
            
        }

    }
}