
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 2f;
    [SerializeField] private Rigidbody2D _rb;

    private int _moveDirection = 0; // Direction to move to in the next fixed update, -1 left, 1 right, 0 do nothing
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TouchMoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void TouchMoveInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                float touchX = Camera.main.ScreenToWorldPoint(touch.position).x;
                if (touchX == transform.position.x) return;
                _moveDirection = touchX > transform.position.x ? 1 : -1;
                
            }
        }
    }

    void Move()
    {
        

        _rb.AddForce(Vector2.right * (_baseSpeed * _moveDirection), ForceMode2D.Impulse);
        _moveDirection = 0;
    }

}
