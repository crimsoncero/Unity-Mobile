using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JunkErraticMove : MonoBehaviour
{
    [SerializeField] float _duration = 4f;
    [SerializeField] Vector3 _randomLocation;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomLocation();
        ErraticMoveTween();
    }

    void ErraticMoveTween()
    {
        transform.DOMove(_randomLocation, _duration).SetEase(Ease.InOutBounce).OnStart(() => SetRandomLocation()).OnComplete(() => ErraticMoveTween());
        transform.DOScale(0.5f, _duration * 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    void SetRandomLocation()
    {
        _randomLocation = RandomScreenLocation();
    }
    Vector3 RandomScreenLocation()
    {
        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        return new Vector3(randomPositionOnScreen.x, randomPositionOnScreen.y, 0);
    }

}
