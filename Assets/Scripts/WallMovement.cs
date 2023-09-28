using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    float _moveX = 0.1f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + _moveX, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            _moveX = -_moveX;
        }
    }
}
