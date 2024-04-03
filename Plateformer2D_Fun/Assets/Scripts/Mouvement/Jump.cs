using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [field: SerializeField] public float Height { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    [field: SerializeField] public float Time { get; set; }
    [field: SerializeField] public float MaxTime { get; set; }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (Time >= MaxTime)
        {
            if (context.performed)
            {
                Rigidbody2D.AddForce(Vector2.up * Height, ForceMode2D.Impulse);
                Time = 0;
            }
        }
    }
}
