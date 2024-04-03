using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private bool _verifGround = false;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_verifGround == true)
        {
            if (context.performed)
            {
                _rigidbody2D.AddForce(Vector2.up * _height, ForceMode2D.Impulse);
                _verifGround = false;
            }
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _verifGround = true;
        }
        //else
        //{
        //    _verifGround = false;
        //}
    }
}
