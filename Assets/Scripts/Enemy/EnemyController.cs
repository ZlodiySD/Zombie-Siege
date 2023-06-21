using System;
using Didenko.AI;
using Didenko.Infrastructure.States;
using Opsive.UltimateCharacterController.Character;
using UnityEngine;
using EventHandler = Opsive.Shared.Events.EventHandler;

namespace Didenko.Enemy
{
  public class EnemyController : MonoBehaviour
  {
    public event Action EnemyDied;

    [SerializeField]
    private AgentMoveToTarget _agentMoveToTarget;
    [SerializeField] 
    private NavMeshMeleeAgent _meleeAgent;
    [SerializeField] 
    private LocalLookSource _localLookSource;
    
    public void Init(Player player)
    {
      _agentMoveToTarget.Init(player.gameObject);
      _meleeAgent.Init(player.gameObject);
      _localLookSource.Target = player.transform;

      SubscribeToEvents();
    }

    private void SubscribeToEvents() => 
      EventHandler.RegisterEvent<Vector3, Vector3, GameObject>(gameObject, "OnDeath", (a1, a2, a3) => EnemyDied?.Invoke());
  }
}