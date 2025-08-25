using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform>();
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

    public Vector3 GetFirstPoint()
    {
        return _points.First().position;
    }
}
