using UnityEngine;

namespace MainCharacter.States
{
    public class RunState : WalkState
    {
        private Rigidbody2D _rigidbody;
        private float _speedRun;
        
        public override void Initialize()
        {
            base.Initialize();
            
            _speedRun = player. SpeedMovement+2;
        }

        public override void Process()
        {
            Move(_speedRun);
        }

       
    }
}
