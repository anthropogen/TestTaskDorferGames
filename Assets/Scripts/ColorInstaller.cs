using UnityEngine;
using System.Linq;
public class ColorInstaller : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private Color _prevColor=Color.black;    
    private Color _prevPreviousColor =Color.black;
   
    public Color GetColor()
    {
        if (_prevColor == Color.black&&_prevPreviousColor==Color.black)
        {
            return _prevColor= colors[Random.Range(0, colors.Length)];
        }
        _prevPreviousColor = _prevColor;
        return _prevColor = ExcludeColor(_prevColor,_prevPreviousColor);   
    }
    private Color ExcludeColor(Color first,Color second)
    {
        Color[] otherColors = colors.Where((p) => p != first&&p!=second).ToArray();
        return _prevColor = otherColors[Random.Range(0, otherColors.Length)];
    }
}
