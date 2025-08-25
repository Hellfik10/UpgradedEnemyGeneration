using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Rigidbody _rigidbody;
    private Transform _target;

    public Rigidbody Rigidbody => _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Transform target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;

        _rigidbody.Move(transform.position + direction * (Time.fixedDeltaTime * _speed), Quaternion.identity);
    }
}
