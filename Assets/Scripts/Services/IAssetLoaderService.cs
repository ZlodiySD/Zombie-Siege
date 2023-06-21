using Didenko.Infrastructure;
using UnityEngine;

namespace Didenko.Services
{
  public interface IAssetLoaderService : IService
  {
    GameObject InstantiateAsset(Vector3 position, string assetPath);
    GameObject InstantiateAsset(string assetPath);
    GameObject InstantiateAsset(string assetPath, Transform parent);
  }
}