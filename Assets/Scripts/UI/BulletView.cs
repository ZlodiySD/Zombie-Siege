using UnityEngine;
using UnityEngine.UI;

namespace Didenko.UI
{
  public class BulletView : MonoBehaviour
  {
    public Image Image;

    private Color _defaultColor;
    private Color _firedColor;

    private void Start()
    {
      _defaultColor = Image.color;
    
      _firedColor = Color.gray;
      _firedColor.a = _defaultColor.a;
    }

    public void Reset()
    {
      Image.color = _defaultColor;
    }

    public void Fire()
    {
      Image.color = _firedColor;
    }
  }
}
