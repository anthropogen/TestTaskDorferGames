
using UnityEngine;

public abstract class Colored : MonoBehaviour
{
    private Renderer _renderer;
    private Color _currentColor;
    public Color Color => _currentColor;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _currentColor = _renderer.material.color;
    }
    public void Paint(Color newColor)
    {
      _currentColor= _renderer.material.color = newColor;
    }

}
