using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    private List<Transform> _points = new List<Transform>();
    private float _distance = 1f;

    private int _currentPointIndex = 0;

    public event Action<Vector3> CurrentPointUpdated;

    private void Update()
    {
        if (transform.position.IsEnoughClose(_points[_currentPointIndex].position, _distance))
        {
            _currentPointIndex = (_currentPointIndex + 1) % _points.Count;
            CurrentPointUpdated?.Invoke(_points[_currentPointIndex].position);
        }
    }

    public void Init(List<Transform> points)
    {
        _points = points;
    }
}
