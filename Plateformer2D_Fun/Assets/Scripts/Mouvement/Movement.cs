using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector2 _value;

    public void OnMouvement(InputAction.CallbackContext context)
    {
        _value = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 mouvement = new Vector3(_value.x, _value.y, 0);
        mouvement.Normalize();
        transform.Translate(_speed * mouvement * Time.deltaTime);
    }
}
