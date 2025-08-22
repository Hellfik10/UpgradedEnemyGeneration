using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PatrolController))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _point;

    private PatrolController _patrolController;

    [SerializeField] private float _speed = 10f;

    public Rigidbody Rigidbody => _rigidbody;


    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _patrolController = GetComponent<PatrolController>();
    }

    private void OnEnable()
    {
        _patrolController.CurrentPointUpdated += SetDirectionToPoint;
    }

    private void OnDisable()
    {
        _patrolController.CurrentPointUpdated -= SetDirectionToPoint;
    }

    public void Init(List<Transform> points)
    {
        _patrolController.Init(points);
        _point = points.First().position;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_point - transform.position).normalized;

        _rigidbody.Move(transform.position + direction * (Time.fixedDeltaTime * _speed), Quaternion.identity);
    }

    private void SetDirectionToPoint(Vector3 point)
    {
        _point = point;
    }
}
