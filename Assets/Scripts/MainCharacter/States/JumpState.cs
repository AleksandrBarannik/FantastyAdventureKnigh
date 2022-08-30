using UnityEngine;

namespace MainCharacter.States
{
    public class JumpState : PlayerState
    {
        private Rigidbody2D _rigidbody;
        private float _jumpForce;
        private Animator _animator;

      

        public override void Initialize()
        {
            base.Initialize();

            _animator = player.animator;
            _rigidbody = player.GetComponent<Rigidbody2D>();
            _jumpForce = player.JumpForce;
        }

        public override void EnterState()
        {
            base.EnterState();
            Jump();
        }

        public override void Process()
        {
            
        }

        public void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

    }
}