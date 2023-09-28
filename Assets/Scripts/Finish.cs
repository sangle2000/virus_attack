using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public DisplayNumber _displayTotal;
    public bool _isFinish = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isFinish = true;
            _displayTotal.DisplayTotal();
        }
    }
}
