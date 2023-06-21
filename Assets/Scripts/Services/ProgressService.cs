using Didenko.Infrastructure;

namespace Didenko.Services
{
  public class ProgressService : IProgressService
  {
    public GameData GameData { get; set; }

    public ProgressService(GameData gameData)
    {
      GameData = gameData;
    }
  }
}