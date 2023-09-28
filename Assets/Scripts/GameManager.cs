using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    Camera _cam;

    public Ball _ball;
    public Trajectory _trajectory;
    public Finish _finish;

    [SerializeField] float _pushForce = 4f;

    public int _count = 0;

    bool isDragging = false;

    Vector2 _startPoint;
    Vector2 _endPoint;
    Vector2 _direction;
    Vector2 _force;
    float _distance;

    private void Start()
    {
        _cam = Camera.main;
        _ball.DesactiveRb();
    }

    private void Update()
    {
        if (!_finish._isFinish && (Input.touchCount > 0))
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                OnDragStart();
            }

            if(touch.phase == TouchPhase.Moved)
            {
                OnDrag();
            }

            if(touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
                OnDragEnd();
            }

 /*           if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();
            }*/
        }
    }

    void OnDragStart()
    {
        _ball.DesactiveRb();
        _startPoint = _cam.ScreenToWorldPoint(Input.mousePosition);

        _trajectory.Show();
    }
    void OnDrag()
    {
        _endPoint = _cam.ScreenToWorldPoint(Input.mousePosition);
        _distance = Vector2.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        _force = _direction * _distance * _pushForce;

        Debug.DrawLine(_startPoint, _endPoint);

        _trajectory.UpdateDots(_ball.pos, _force);
    }
    void OnDragEnd()
    {
        _ball.ActiveRb();
        _ball.Push(_force);

        _trajectory.Hide();

        _count++;
    } 
}
