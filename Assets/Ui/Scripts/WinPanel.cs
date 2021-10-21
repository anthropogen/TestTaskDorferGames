using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text foodLabel;
    [SerializeField] private TMP_Text crystalLabel;
    [SerializeField] private Jaws jaws;

    private void OnEnable()
    {
        foodLabel.text = jaws.Food.ToString();
        crystalLabel.text = jaws.Crystal.ToString();
    }
}
