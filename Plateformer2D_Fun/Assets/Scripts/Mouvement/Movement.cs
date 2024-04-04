using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [field: SerializeField] public int Speed { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    private bool _isFacingRight = true;
    private Vector2 _value;
    [field: SerializeField] public bool PlayerController { get; set; }

    private void Start()
    {
        PlayerController = true;
    }

    public void OnMouvement(InputAction.CallbackContext context)
    {
        _value = context.ReadValue<Vector2>();
    }

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    private void FixedUpdate()
    {
        if (PlayerController == true)
        {
            Vector3 mouvement = new Vector3(_value.x, _value.y, 0);
            mouvement.Normalize();
            transform.Translate(Speed * mouvement * Time.deltaTime);

            if (!_isFacingRight && _value.x > 0)
            {
                Flip();
            }
            else if (_isFacingRight && _value.x < 0)
            {
                Flip();
            }
        }
        
    }
}
