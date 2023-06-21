using Didenko.Infrastructure;

namespace Didenko.Services
{
  public interface IProgressService : IService
  {
    GameData GameData { get; set; }
  }
}