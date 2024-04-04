using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [field: SerializeField] public float Height { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    private bool _isGonnaJump = false;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isGonnaJump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && _isGonnaJump == true)
        {
            Rigidbody2D.AddForce(Vector2.up * Height, ForceMode2D.Impulse);
            _isGonnaJump = false;
        }
    }
}
