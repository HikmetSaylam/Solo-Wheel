using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleAnimation : MonoBehaviour
{
    private Vector3 _startTransform;
    private Vector3 _endTransform;
    [SerializeField] [Range(0, 1)] private float lerpValue;
    [SerializeField] private float startPosX;
    [SerializeField] private float endPosX;
    private bool _isBack;

    private void Awake()
    {
        _startTransform = transform.position;
        _endTransform = transform.position;
        _endTransform.x += (endPosX - startPosX);
        _isBack = false;
    }

    private void FixedUpdate()
    {
        if (!_isBack)
        {
            transform.position = Vector3.Lerp(_startTransform, _endTransform, lerpValue+=0.01f);
            if (lerpValue >= 1)
                _isBack = true;
        }
        else
        {
            transform.position = Vector3.Lerp(_startTransform, _endTransform, lerpValue-=0.01f);
            if (lerpValue <= 0)
                _isBack = false;
        }
    }
}
