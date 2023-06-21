using System;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;
using EventHandler = Opsive.Shared.Events.EventHandler;

namespace Didenko.Infrastructure.States
{
  public class Player: MonoBehaviour
  {
    private CharacterHealth _characterHealth;
    public event Action Died;

    private void Start()
    {
      EventHandler.RegisterEvent<Vector3, Vector3, GameObject>(gameObject, "OnDeath", OnDeath);
      _characterHealth = gameObject.GetComponent<CharacterHealth>();
    }
    
    private void OnDeath(Vector3 arg1, Vector3 arg2, GameObject arg3)
    {
      Died?.Invoke();
    }
  }
}