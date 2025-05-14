using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<float> VelueChenged;

    [SerializeField] private float _deley;
    [SerializeField, Min(0)] private float _startCount;

    private float _currentCount;
    private bool _isOn = false;

    private Coroutine _countupCoroutine;

    private void Start()
    {
        _currentCount = _startCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isOn = !_isOn;

            if (_isOn)
            {
                if (_countupCoroutine == null)
                    _countupCoroutine = StartCoroutine(Countup());
            }
            else
            {
                if (_countupCoroutine != null)
                {
                    StopCoroutine(Countup());
                    _countupCoroutine = null;
                }
            }

        }
    }

    private IEnumerator Countup()
    {
        var wait = new WaitForSecondsRealtime(_deley);

        while (_isOn)
        {
            VelueChenged?.Invoke(_currentCount++);

            yield return wait;
        }
    }
}
