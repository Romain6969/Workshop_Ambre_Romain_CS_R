using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _rigidbody2D.AddForce(Vector2.up * _height, ForceMode2D.Impulse);
        }
    }
}
