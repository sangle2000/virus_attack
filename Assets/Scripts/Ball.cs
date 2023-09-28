using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D _rb;
    [HideInInspector] public CircleCollider2D _col;

    [HideInInspector] public Vector3 pos
    {
        get { return transform.position; }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        _rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActiveRb()
    {
        _rb.isKinematic = false;
    }
    
    public void DesactiveRb()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = 0f;
        _rb.isKinematic = true;
    }
}
