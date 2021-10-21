using UnityEngine;
using UnityEngine.Events;
public class Jaws : MonoBehaviour
{
    [SerializeField] private Sneak sneak;
    [SerializeField] private SneakHead head;
    [SerializeField] private int needCrystalToFever;
    private int _eatenCrystalInRow;
    private int _eatenFood;
    private int _eatenCrystal;
    public int Crystal => _eatenCrystal;
    public int Food => _eatenFood;
    public event UnityAction Fever;
    public event UnityAction<int> EatenFoodChanged;
    public event UnityAction<int> EatenCrystalChanged;
    public event UnityAction Died;
    private void OnEnable()
    {
        sneak.FeverEnded += ResetCrystal;
    }
    private void OnDisable()
    {
        sneak.FeverEnded -= ResetCrystal;
    }
    private void Start()
    {
        _eatenFood = 0;
        ResetCrystal();
        EatenFoodChanged?.Invoke(_eatenFood);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            if (food != null)
            {
                CheckFood(food);
            }
        }
        else if (other.TryGetComponent(out Crystal crystal))
        {
            if (crystal != null)
            {
                CheckCrystal(crystal);
            }
        }
    }
    private void CheckFood(Food food)
    {
        if (!sneak.IsFever)
        {
            if (food.Color != head.Color)
            {
                sneak.gameObject.SetActive(false);
                Died?.Invoke();
                return;
            }
        }
        _eatenFood++;
        EatenFoodChanged?.Invoke(_eatenFood);
        _eatenCrystalInRow = 0;
        food.gameObject.SetActive(false);
    }
    private void CheckCrystal(Crystal crystal)
    {
        _eatenCrystalInRow++;
        _eatenCrystal++;
        EatenCrystalChanged?.Invoke(_eatenCrystal);
        if (_eatenCrystalInRow == needCrystalToFever)
        {
            Fever?.Invoke();
        }
        crystal.gameObject.SetActive(false);
    }
    private void ResetCrystal()
    {
        _eatenCrystal = 0;
        _eatenCrystalInRow = 0;
        EatenCrystalChanged?.Invoke(_eatenCrystal);
    }
}
