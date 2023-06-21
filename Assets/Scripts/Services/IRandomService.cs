using Didenko.Infrastructure;

namespace Didenko.Services
{
  public interface IRandomService : IService
  {
    int Next(int min, int max);
  }
}