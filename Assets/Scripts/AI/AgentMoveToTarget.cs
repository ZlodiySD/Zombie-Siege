using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities.AI;
using UnityEngine;
using EventHandler = Opsive.Shared.Events.EventHandler;

namespace Didenko.AI
{
  public class AgentMoveToTarget : MonoBehaviour
  {
    public GameObject _target;
    
    private Transform _moveTarget;
    private NavMeshAgentMovement _navMeshAgentMovement;
    private Transform _selfTransform;
    private bool _isDead;
    private bool _targetIsDead;

    public void Init(GameObject target)
    {
      _target = target;
      _moveTarget = target.transform;
      _selfTransform = gameObject.transform;
      
      var characterLocomotion =
        gameObject.GetComponent<UltimateCharacterLocomotion>();
      _navMeshAgentMovement = characterLocomotion.GetAbility<NavMeshAgentMovement>();

      RegisterEvents();
    }

    private void Update()
    {
      if (!_target)
        return;
      
      if (_isDead || _targetIsDead)
        return;
      
      _navMeshAgentMovement.SetDestination(_moveTarget.position);
    }

    private void RegisterEvents()
    {
      EventHandler.RegisterEvent<Vector3, Vector3, GameObject>(gameObject, "OnDeath", OnDeath);
      EventHandler.RegisterEvent<Vector3, Vector3, GameObject>(_target, "OnDeath", (a1, a2, a3) => _targetIsDead = true);
      EventHandler.RegisterEvent(gameObject, "OnRespawn", OnRespawn);
    }

    private void OnRespawn()
    {
      _navMeshAgentMovement.Enabled = true;
      _isDead = false;
    }

    private void OnDeath(Vector3 arg1, Vector3 arg2, GameObject arg3)
    {
      _navMeshAgentMovement.Enabled = false;
      _isDead = true;
    }
  }
}
