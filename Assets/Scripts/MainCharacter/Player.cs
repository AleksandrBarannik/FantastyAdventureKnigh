using Common;
using Common.Audio;
using UnityEngine;
using UnityEngine.Rendering;
using MainCharacter.States;
using UnityEngine.UI;

namespace MainCharacter
{
    public class Player : MonoBehaviour
    {
        #region Fields
        
        public static Player Instance;
        
        [Header ("Buttons")]
        
        [Tooltip("Кнопка атаки")]
        public Button buttonAttack;
        
        [Tooltip("Кнопка прыжка")]
        public Button buttonJump;
        
        [Header("Movement/Jump")] 
        
        [SerializeField]
        private Joystick _joystick;
        public Joystick Joystick => _joystick;
        
        [SerializeField]
        private float _speedMovement = 2f;
        public float SpeedMovement => _speedMovement;
        
        [SerializeField]
        private float _jumpForce = 55f;
        public float JumpForce => _jumpForce;
        
        [Header("Graphic")] 
        
        [SerializeField]
        public Animator animator;

        [Header("Ground checker")] 
        
        [SerializeField][Tooltip("Точка соприкосновения с землей")]
        private Transform _groundCheckPoint;
        public Transform GroundCheckPoint => _groundCheckPoint;
        
        [Range(0.01f, 1f)]
        [SerializeField][Tooltip("Радиус точки соприкосновения (для отрисовки сферы(гизмос)")]
        private float groundCheckRadius = 0.4f;
        
        [SerializeField][Tooltip("Слой земли по который ходим")]
        private LayerMask whatIsGround;

        [Header("Gizmos")] 
        private bool _gizmosEnabled = true;
        private Color groundCheckColor = Color.magenta;

        [Header("Attack Properties")]
        
        [SerializeField][Tooltip("Наносимый врагу урон")]
        public int attackDamage = 5;
        
        [SerializeField][Tooltip("Точка атаки относительно которой противник получает урон")]
        private Transform _attackPoint;
        public Transform AttackPoint => _attackPoint;
        
        [SerializeField][Tooltip("Диапазон(радиус) атаки")]
        private float _attackRadius = 0.5f;
        public float AttackRadius => _attackRadius;
        
        [SerializeField][Tooltip("Дополнительное время ожидания атаки")]
        private float _attackDelay = 1f;
        public float AttackDelay => _attackDelay;
        
        
        
        [SerializeField][Tooltip("Время ожидания перед уменьшением здоровья врага и запуском звука удара")]
        private float _punchDelay = 1f;
        public float PunchDelay => _punchDelay;
        
        [SerializeField][Tooltip("Время ожидания перед дективацией обьекта MainCharacter")]
        private float disableDelay = 1f;
        public float DisableDelay => disableDelay;
        
        private IdleState _idleState;
        private RunState _runState;
        private JumpState _jumpState;
        private WalkState _walkState;
        private AttackState _attackState;
        private DeathState _deathState;
        
        private PlayerState _currentState;

        private bool _isGrounded = false;
        public bool IsGrounded => _isGrounded;
        
        private static readonly int Walk = Animator.StringToHash("Speed");
        private static readonly int IsJump = Animator.StringToHash("IsJump");
        
        
        private Health _health;
        public Health Health => _health;
        
        #endregion Fields
        
       
        #region MonoBehaviour
        private void Awake()
        {
            Instance = this;

            animator = GetComponent<Animator>();
            
            _health = GetComponent<Health>();

            _idleState = new IdleState
            {
                player = this
            };

            _runState = new RunState
            {
                player = this
            };
            
            _walkState = new WalkState
            {
                player = this
            };

            _jumpState = new JumpState
            {
                player = this
            };
            
            _attackState = new AttackState()
            {
                player = this
            };
            
            _deathState = new DeathState()
            {
                player = this
            };
                
            
            _idleState.onEnterState.AddListener(delegate
            {
                animator.SetFloat(Walk, 0);    
            });
            
            _runState.onEnterState.AddListener(delegate
            {
                animator.SetFloat(Walk,  SpeedMovement);
                //AudioController.Instance.Play("Steps");
                
            });
            
            _jumpState.onEnterState.AddListener(delegate
            {
                animator.SetBool(IsJump, true);
            });
            
            _health.onDecreaseHealth.AddListener(delegate
            {
                animator.Play("Hit");
            });
            
            _health.onZeroHealth.AddListener(delegate
            {
                animator.Play("Stun");
                SetState(_deathState);
            });
            
            buttonAttack.onClick.AddListener(delegate
            {
                SetState(_attackState);
            });
            
            buttonJump.onClick.AddListener(delegate
            {
                if (_isGrounded)
                {
                    SetState(_jumpState);
                }
            });
            
           
            
            _idleState.Initialize();
            _runState.Initialize();
            _jumpState.Initialize();
            _walkState.Initialize();
            _attackState.Initialize();
            _deathState.Initialize();
           
            
        }

        private void Start()
        {
           
            SetState(_idleState);
        }

        private void Update()
        {
            CheckState();
            
            _currentState.Process();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }
        
        #endregion MonoBehaviour

        private void CheckState()
        {
            animator.SetBool(IsJump, false);
            CheckSide();
           
            /*
            //For PC
            if (Input.GetKey(KeyCode.Space) && _isGrounded)
            {
                SetState(_jumpState);
            }            
            
            if (Input.GetButtonDown("Fire1")) 
            {
                SetState(_attackState);
            }
            
            */
            
            if (_joystick.Horizontal == 0 && _currentState != _idleState )
            {
                SetState(_idleState);
            }
            else if (_joystick.Horizontal != 0 && _currentState != _runState)
            {
                SetState(_runState);
            }
           
        }

        private void SetState(PlayerState playerState)
        {
            _currentState?.FinishState();
            _currentState = playerState;
            _currentState.EnterState();
        }

        private void CheckSide()//Для поворота игрока в нужную сторону
        {
            if (_joystick.Horizontal == 0) return;
            transform.localScale = _joystick.Horizontal < 0 ? 
                new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : 
                new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        private void CheckGround() //Для приземления после прыжка
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(
                GroundCheckPoint.position, 
                groundCheckRadius, 
                whatIsGround);

            _isGrounded = colliders.Length >= 1;
        }

        
        private void OnDrawGizmos()
        {
            if (!_gizmosEnabled) return;
            if (!GroundCheckPoint) return;

            Gizmos.color = groundCheckColor;
            Gizmos.DrawWireSphere(GroundCheckPoint.position, groundCheckRadius);
            Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
        }
    }
}
