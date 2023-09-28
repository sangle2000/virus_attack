using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int _dotsNumber;
    [SerializeField] GameObject _dotsParent;
    [SerializeField] GameObject _dotPrefab;
    [SerializeField] float _dotSpacing;
    [SerializeField] [Range(0.01f, 0.3f)] float _dotMinScale;
    [SerializeField] [Range(0.3f, 1f)] float _dotMaxScale;

    Transform[] _dotsList;
    
    Vector2 _pos;
    float _timeStamp;

    private void Start()
    {
        Hide();

        PrepareDots();
    }

    void PrepareDots()
    {
        _dotsList = new Transform[_dotsNumber];
        _dotPrefab.transform.localScale = Vector3.one * _dotMaxScale;

        float _scale = _dotMaxScale;
        float _scaleFactor = _scale / _dotsNumber;

        for(int i = 0; i < _dotsNumber; i++)
        {
            _dotsList[i] = Instantiate(_dotPrefab, null).transform;
            _dotsList[i].parent = _dotsParent.transform;

            _dotsList[i].transform.localScale = Vector3.one * _scale;

            if(_scale > _dotMinScale)
            {
                _scale -= _scaleFactor;
            }
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        _timeStamp = _dotSpacing;
        for(int i = 0; i < _dotsNumber; i++)
        {
            _pos.x = (ballPos.x + forceApplied.x * _timeStamp);
            _pos.y = (ballPos.y + forceApplied.y * _timeStamp) - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2f;

            _dotsList[i].position = _pos;
            _timeStamp += _dotSpacing;
        }
    }

    public void Show()
    {
        _dotsParent.SetActive(true);
    }
    
    public void Hide()
    {
        _dotsParent.SetActive(false);
    }
}
