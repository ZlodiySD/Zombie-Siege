using UnityEngine;

namespace Didenko.Services
{
  public class AssetLoaderService : IAssetLoaderService
  {
    public GameObject InstantiateAsset(Vector3 position, string assetPath)
    {
      var prefab = Resources.Load<GameObject>(assetPath);
      return Object.Instantiate(prefab, position, Quaternion.identity);
    }

    public GameObject InstantiateAsset(string assetPath)
    {
      var prefab = Resources.Load<GameObject>(assetPath);
      return Object.Instantiate(prefab);
    }
    
    public GameObject InstantiateAsset(string assetPath, Transform parent)
    {
      var prefab = Resources.Load<GameObject>(assetPath);
      return Object.Instantiate(prefab, parent);
    }
  }
}