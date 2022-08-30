using System.Collections.Generic;
using Common;
using Enemys.States;
using Utilites;
using UnityEngine;
using World.Enemy.Scripts.States;

namespace Enemys
{
    public class Enemy : MonoBehaviour
    {
        public Transform player;
    
        private Rigidbody2D rigidbody;
       
        [Header("Graphic")]
        public Animator animator;

        [Header("PathPoint")]
        
        [SerializeField][Tooltip("Начальня точка генерации промежуточных точек")]
        private Transform _beginPoint;

        [SerializeField][Tooltip("Конечная точка генерации промежуточных точек")]
        private Transform _endPoint;
        
        [SerializeField][Tooltip("Дистанция через которую генер точки")]
        private float _randomPointDistance = 2f;
        
        private readonly List<Vector3> path = new List<Vector3>();
        private Vector3 lastRandomPointPosition;
        private Vector3 currentTarget;
        public Vector3[] Path => path.ToArray();
    
        [Header("EnemyAttackParametrs")]
        
        [SerializeField][Tooltip("Урон наносимый герою")]
        private int _damage = 40;
        public int Damage => _damage;
        
        [SerializeField][Tooltip("Точка атаки которая наносит урон")]
        private Transform _attackPoint;
        public Transform AttackPoint => _attackPoint;
        
        [SerializeField][Tooltip("Радиус в котором наносится урон")]
        private float _attackRadius = 0.5f;
        public float AttackRadius => _attackRadius;
        
        [SerializeField][Tooltip("Дополнительное время ожидания атаки")]
        private float _attackDelay = 1f;
        public float AttackDelay => _attackDelay;

        [SerializeField][Tooltip("Время ожидания перед уменьшением здоровья врага и запуском звука удара")]
        private float _punchDelay = 1f;
        public float PunchDelay => _punchDelay;
    
    
        [Header("EnemyStat")]    
        
        [SerializeField][Tooltip("скорость передвижения")]
        private float _speedMovement = 4f;
        public float SpeedMovement => _speedMovement;

        [SerializeField][Tooltip("скорость Перехода в Бег")]
        private float _speedRun = 6f;
        public float SpeedRun => _speedRun;
        
        [SerializeField][Tooltip("Время ожидание в состоянии Idle")]
        private float _timeIdle = 2;
        public float TimeIdle => _timeIdle;


        [Header("Death")] 
        
        [SerializeField] private DropEnemyItem[] items;
        public Health Health => _health;
        private Health _health;
        
        [SerializeField]
        private GameObject UI_health;

        [Header("EnemyDiedParametrs")]
        
        [SerializeField][Tooltip("Время 1")]
        private float _hurtTime = 5f;
        public float HurtTime => _hurtTime;
        
        [SerializeField][Tooltip("Время до уничтожения мертвого врага")]
        private float _timeTodestroy = 2f;
        public float TimeToDestroy => _timeTodestroy;

        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int Walk = Animator.StringToHash("Speed");

        private EnemyState _currentEnemyState;
        private EnemyIdleState _idleEnemyState;
        private EnemyPatrolState _patrolEnemyState;
        private EnemyAttackState _attackEnemyState;
        private EnemyShadowingState _shadowingEnemyState;
        private EnemyContusionState _contusionEnemyState;
        private EnemyDeathState _deathEnemyState;

        private bool _isAlive = true;
        public bool IsAlive => _isAlive;
        
        private void Awake()
        {
            _health = GetComponent<Health>();
             rigidbody = GetComponent<Rigidbody2D>();
             UI_health= GameObject.FindWithTag("Health");
        
            InitializePath();
            
            _idleEnemyState = new EnemyIdleState
            {
                enemy = this
            };
        
            _patrolEnemyState = new EnemyPatrolState
            {
                enemy = this
            };
        
            _attackEnemyState = new EnemyAttackState
            {
                enemy = this
            };
        
            _shadowingEnemyState = new EnemyShadowingState
            {
                enemy = this
            };

            _contusionEnemyState = new EnemyContusionState
            {
                enemy = this

            };

            _deathEnemyState = new EnemyDeathState()
            {
                enemy = this
            };
        
        
            _idleEnemyState.endEnemyState = _patrolEnemyState;
            _patrolEnemyState.endEnemyState = _idleEnemyState;
            _attackEnemyState.endEnemyState = _shadowingEnemyState;
            _shadowingEnemyState.endEnemyState = _patrolEnemyState;
            
            
            _idleEnemyState.Initialize();
            _patrolEnemyState.Initialize();
            _attackEnemyState.Initialize();
            _shadowingEnemyState.Initialize();
            _contusionEnemyState.Initialize();
            _deathEnemyState.Initialize();



            _patrolEnemyState.onEnterState.AddListener(delegate
            {
                animator.SetFloat(Walk, SpeedMovement); 
            });
        
            _idleEnemyState.onEnterState.AddListener(delegate
            {
                SetBoolAnimation(Idle, false);    
            });
        
        
            _shadowingEnemyState.onEnterState.AddListener(delegate
            {
                animator.SetFloat(Walk, SpeedRun); 
            });
            
            _health.onDecreaseHealth.AddListener(delegate
            {
                SetState(_contusionEnemyState);
            });
            
            _health.onZeroHealth.AddListener(delegate
            {
                if (!_isAlive) return;
                
                SetState(_deathEnemyState);
                DropItem();
                _isAlive = false;
                
            });
        }
    
        private void Start()
        {
            SetState(_idleEnemyState);
        }
    
        private void FixedUpdate()
        {
            _currentEnemyState.Process();
        }

        public void SetState(EnemyState enemyState)
        {
           if (_currentEnemyState == _deathEnemyState) return;
            
            _currentEnemyState?.FinishState();
            _currentEnemyState = enemyState;
            _currentEnemyState.EnterState();
        }
   
    
        private void InitializePath()
        {
            if (_randomPointDistance < 0.01f) return;
            if (!_beginPoint || !_endPoint)
            {
                path.Add(transform.position);
                return;
            }
            _beginPoint.position = new Vector3(_beginPoint.position.x, transform.position.y);
            _endPoint.position = new Vector3(_endPoint.position.x, transform.position.y);
        
            path.Add(_beginPoint.position);
            lastRandomPointPosition = _beginPoint.position + Vector3.right * _randomPointDistance;
            while (lastRandomPointPosition.x < _endPoint.position.x)
            {
                path.Add(lastRandomPointPosition);
                lastRandomPointPosition += Vector3.right * _randomPointDistance;
            }
            path.Add(_endPoint.position);
        }
    
        public void CheckSide(Vector3 target)
        {
            Vector3 localScale = transform.localScale;

            float scaleX = transform.localScale.x;
            
            transform.localScale = new Vector3(
                Mathf.Abs(localScale.x) * AlexMath.GetObjectSide(transform.position, target), 
                localScale.y, 
                localScale.z);

            if (scaleX != transform.localScale.x && _currentEnemyState == _shadowingEnemyState)
            {
                Disable();
                Invoke(nameof(Enable), 2);
            }
        }

        private void Disable() => enabled = false;
        private void Enable() => enabled = true;
        
        
        private void StartPunching()
        {
            SetState(_attackEnemyState);
        }
        
        private void EndPunching()
        {
            SetState(_shadowingEnemyState);
        }
    
        private void StartShadowing()
        {
            SetState(_shadowingEnemyState);
        }
        public void EndShadowing()
        {
            SetState(_patrolEnemyState);
        }
    
    
    
        private void SetBoolAnimation(int anim, bool enable)
        {
            animator.SetBool(anim, enable);
        }

        public void PlayAnimation(string anim)
        {
            animator.Play(anim);
        }


        private void DropItem()
        {
            foreach (var elem in items)
            {
                for (int i = 0; i < elem.count; i++)
                {
                    
                    Rigidbody2D newRb = Instantiate(elem.prefab, transform.position,
                        Quaternion.identity).GetComponent<Rigidbody2D>();
                    newRb.AddForce(new Vector2(Random.Range(-8, 8), Random.Range(4,8)));
                   
                }
            }
        }
        
        private void OnDrawGizmos()
        {
            foreach (var elem in path)
            {
                Gizmos.DrawWireSphere(elem,0.3f);
            }
        }

   

   




    }
}
