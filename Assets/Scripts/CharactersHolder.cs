using System.Collections.Generic;
using Didenko.Enemy;
using Didenko.Infrastructure.States;
using UnityEngine;

namespace Didenko
{
  public class CharactersHolder : MonoBehaviour
  {
    [SerializeField]
    private List<EnemyController> _enemies;
    [SerializeField] 
    private Player _player;

    public Player Player => _player;

    public List<EnemyController> Enemies => _enemies;
  }
}