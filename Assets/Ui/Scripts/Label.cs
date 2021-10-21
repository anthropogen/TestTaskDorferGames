using UnityEngine;
using TMPro;
public class Label : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    protected void OnValuerChanged(int value)
    {
        label.text = value.ToString();
    }
}
