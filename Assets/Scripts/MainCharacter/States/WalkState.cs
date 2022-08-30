using System.Collections;
using Common.Audio;
using UnityEngine;

namespace MainCharacter.States
{
    public class WalkState : PlayerState
    {
        private Rigidbody2D _rigidbody;
        private float _speedMovement;
        private Joystick _joystick;
        private MonoBehaviour _monoBehaviour;
        private IEnumerator playSoundCorutine;
        
        public override void Initialize()
        {
            base.Initialize();
            
            _rigidbody = player.GetComponent<Rigidbody2D>();
            _joystick = player.Joystick;
            
            _speedMovement = player.SpeedMovement;
            _monoBehaviour = player.GetComponent<MonoBehaviour>();

            playSoundCorutine = PlaySoundDelay();
            
            onEnterState.AddListener(delegate
            {
                _monoBehaviour.StartCoroutine(playSoundCorutine);
            });
            
            onFinishState.AddListener(delegate
            {
                _monoBehaviour.StopCoroutine(playSoundCorutine);
            });
        }

        public override void Process()
        {
            Move(_speedMovement);
            
        }

        public void Move(float speed)
        {
            float moveX = _joystick.Horizontal;
            _rigidbody.velocity = new Vector2(moveX * speed, _rigidbody.velocity.y);
           //AudioController.Instance.Play("Steps");
        }
        
        IEnumerator PlaySoundDelay()
        {
            while (true)
            {
                AudioController.Instance.Play("Steps");
                yield return new WaitForSeconds(0.7f);
            }
        }

       
    }
}