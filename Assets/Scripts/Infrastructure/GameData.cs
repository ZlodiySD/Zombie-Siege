using System;
using Didenko.Data;

namespace Didenko.Infrastructure
{
  [Serializable]
  public class GameData
  {
    public KillData KillData;

    public GameData(KillData killData)
    {
      KillData = killData;
    }
  }
}