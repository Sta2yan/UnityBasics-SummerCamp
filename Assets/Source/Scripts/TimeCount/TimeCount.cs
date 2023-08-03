using System;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    [SerializeField, Min(0)] private float _targetInSeconds;

    private bool _enabled = true;

    public float CurrentTime { get; private set; }
    public float TargetInSeconds => _targetInSeconds;

    public event Action Ended;
    
    private void Update()
    {
        Execute();
    }

    private void Execute()
    {
        if (_enabled == false)
            return;
        
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= _targetInSeconds == false) 
            return;
        
        _enabled = false;
        Ended?.Invoke();
    }
}
