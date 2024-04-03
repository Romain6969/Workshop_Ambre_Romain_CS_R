using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [field: SerializeField] public float Height { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    private bool _verifGround = false;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_verifGround == true)
        {
            if (context.performed)
            {
                Rigidbody2D.AddForce(Vector2.up * Height, ForceMode2D.Impulse);
                _verifGround = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            _verifGround = true;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(_verifGround);
    }
}
