using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightMovement : MonoBehaviour
{
    [SerializeField] float _endY = -2.5f;
    [SerializeField] float _duration = 1.7f;
    [SerializeField] Color _endColor;
    [SerializeField] Light2D _light2D;


    // Start is called before the first frame update
    void Start()
    {
        MovementTween();
    }

    void MovementTween()
    {
        transform.DOMoveY(_endY, _duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).OnStart(() => ChangeColor());
    }

    void ChangeColor()
    {
        Color _startColor = _light2D.color;
        DOVirtual.Color(_startColor, _endColor, _duration, (value) =>
        {
            _light2D.color = value;
        }).SetLoops(-1, LoopType.Yoyo);

    }
    
}
