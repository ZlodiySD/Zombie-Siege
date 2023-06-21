using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities.AI;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using Opsive.UltimateCharacterController.Utility;
using UnityEngine;
using EventHandler = Opsive.Shared.Events.EventHandler;

namespace Didenko.AI
{
    public class NavMeshMeleeAgent : MonoBehaviour
    {
        [SerializeField]
        private MinMaxFloat _attackInterval = new MinMaxFloat(2, 4);

        [SerializeField] 
        private float _targetDistance = 3;
        
        public GameObject _target;
        private Transform _targetTransform;
        private Transform _transform;
        private UltimateCharacterLocomotion _characterLocomotion;
        private NavMeshAgentMovement _agentMovement;
        private Use _useAbility;
        
        private float _attackTimer;
        private float _nextAttackTimer;
        
        private bool _isDead;
        private bool _targetIsDead;

        public void Init(GameObject target)
        {
            _target = target;
            _targetTransform = target.transform;
            
            _transform = transform;
            _characterLocomotion = GetComponent<UltimateCharacterLocomotion>();
            _agentMovement = _characterLocomotion.GetAbility<NavMeshAgentMovement>();
            _useAbility = _characterLocomotion.GetAbility<Use>();
            
            RegisterEvents();
        }


        public void Update()
        {
            if (!_target)
                return;
            
            if (_isDead || _targetIsDead)
                return;
            
            if (IsAttackPossible()) 
                Attack();
        }

        private bool IsAttackPossible()
        {
            if (!IsInRange())
                SetAttackTimer();
            
            return IsInRange() && !IsAttackOnTimer();
        }

        private void RegisterEvents()
        {
            EventHandler.RegisterEvent<Vector3, Vector3, GameObject>(_target, "OnDeath", (a1, a2, a3) => _targetIsDead = true);
            EventHandler.RegisterEvent<Vector3, Vector3, GameObject>(gameObject, "OnDeath", OnDeath);
            EventHandler.RegisterEvent(gameObject, "OnRespawn", OnRespawn);
        }

        private bool IsAttackOnTimer()
        {
            _nextAttackTimer -= Time.deltaTime;

            return _nextAttackTimer >= 0;
        }

        private bool IsInRange()
        {
            var distance = (_targetTransform.position - _transform.position).magnitude;

            if (distance > _targetDistance)
                return false;
            
            return true;
        }

        private void Attack()
        {
            _characterLocomotion.TryStartAbility(_useAbility);

            SetAttackTimer();
        }

        private void SetAttackTimer() => 
            _nextAttackTimer = _attackInterval.RandomValue;

        private void OnRespawn() => 
            _isDead = false;

        private void OnDeath(Vector3 arg1, Vector3 arg2, GameObject arg3) => 
            _isDead = true;
    }
}
