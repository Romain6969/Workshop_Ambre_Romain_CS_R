using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [field: SerializeField] public int Speed { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
    private bool _isFacingRight = true;
    private Vector2 _value;
    [field: SerializeField] public bool PlayerController { get; set; }
    [SerializeField] private Animator _animatorShooter;
    [SerializeField] private Animator _animatorSmall;
    [SerializeField] private SpriteRenderer _spriteRendererShooter;
    [SerializeField] private Sprite _spriteShooter;
    [SerializeField] private SpriteRenderer _spriteRendererSmall;
    [SerializeField] private Sprite _spriteSmall;

    private void Start()
    {
        PlayerController = true;
        _animatorShooter.enabled = false;
        _animatorSmall.enabled = false;
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

            if (_value.x > 0)
            {
                _animatorShooter.enabled = true;
                _animatorSmall.enabled = true;

                if (!_isFacingRight)
                {
                    Flip();
                }
            }
            else if (_value.x < 0)
            {
                _animatorShooter.enabled = true;
                _animatorSmall.enabled = true;

                if (_isFacingRight)
                {
                    Flip();
                }
            }
            else
            {
                _spriteRendererShooter.sprite = _spriteShooter;
                _spriteRendererSmall.sprite = _spriteSmall;
                _animatorShooter.enabled = false;
                _animatorSmall.enabled = false;
            }
        }
    }
}
