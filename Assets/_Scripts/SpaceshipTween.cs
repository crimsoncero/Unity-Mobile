using DG.Tweening;
using UnityEngine;

public class SpaceshipTween : MonoBehaviour
{
    [SerializeField] Vector3 _start;
    [SerializeField] Vector3 _end;
    [SerializeField] float _cycleDuration;
    [SerializeField] Transform _transformGFX;

    private bool _isFacigRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
       LerpMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LerpMovement()
    {
        transform.DOMove(_end, _cycleDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).OnStepComplete(() => Flip());
    }

    void Flip()
    {
        float z = 0f;
        if (_isFacigRight)
        {
            z = 90f;
            _isFacigRight = false;
        }
        else
        {
            z = -90f;
            _isFacigRight = true;
        }

        _transformGFX.DORotate(new Vector3(0, 0, z), 1, RotateMode.Fast);
    }
}
