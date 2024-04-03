using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [field: SerializeField] public int Speed { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    private Vector2 _value;

    public void OnMouvement(InputAction.CallbackContext context)
    {
        _value = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 mouvement = new Vector3(_value.x, _value.y, 0);
        mouvement.Normalize();
        transform.Translate(Speed * mouvement * Time.deltaTime);
    }
}
