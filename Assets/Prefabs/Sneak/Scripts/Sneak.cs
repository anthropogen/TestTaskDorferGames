using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class Sneak : MonoBehaviour
{
    [SerializeField] private TailGenerator generator;
    [SerializeField] private NormarMovement normarMovement;
    [SerializeField] private FeverMovement feverMovement;
    [SerializeField] private Movement currentMovement;
    [SerializeField] private Jaws jaws;
    private bool _isFever;
    private List<Segment> _tail;
    public bool IsFever => _isFever;
    public event UnityAction FeverEnded;
    private void Awake()
    {
        _tail = generator.Generate();
        currentMovement = normarMovement;
        _isFever = false;
    }
    private void OnEnable()
    {
        jaws.Fever += OnFever;
    }
    private void OnDisable()
    {
        jaws.Fever -= OnFever;
    }

    private void FixedUpdate()
    {
        currentMovement.Move(_tail);
    }
    public void OnFever()
    {
        StartCoroutine(Fever());
    }
   private IEnumerator Fever()
    {
        currentMovement = feverMovement;
        _isFever = true;
        yield return new WaitForSeconds(5f);
        _isFever = false;
        currentMovement = normarMovement;
        FeverEnded?.Invoke();
    }
}
