using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _deley;
    [SerializeField, Min(0)] private float _startCount;

    private float _currentCount;

    private Coroutine _increaseValueCoroutine;

    public event Action<float> ValueChanged;

    private void Start()
    {
        _currentCount = _startCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_increaseValueCoroutine == null)
            {
                _increaseValueCoroutine = StartCoroutine(IncreaseValue());
            }
            else
            {
                StopCoroutine(_increaseValueCoroutine);
                _increaseValueCoroutine = null;
            }
        }
    }

    private IEnumerator IncreaseValue()
    {
        var wait = new WaitForSeconds(_deley);

        while (enabled)
        {
            ValueChanged?.Invoke(++_currentCount);

            yield return wait;
        }
    }
}