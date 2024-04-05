using UnityEngine;

public class Ennemie : MonoBehaviour
{
    [SerializeField] private float _walk;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    private float _time;
    private bool _isFacingRight = true;

    private void Start()
    {
        _animator.enabled = false;
    }

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    public void Update()
    {
        _time += Time.deltaTime;

        if (_time <= _walk)
        {
            _animator.enabled = true;
            transform.Translate(Vector2.left * _speed * Time.deltaTime);

            if (!_isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            _animator.enabled = true;
            transform.Translate(Vector2.right * _speed * Time.deltaTime);

            if (_isFacingRight)
            {
                Flip();
            }
        }

        if (_time >= _walk * 2)
        {
           _time = 0;
        }
    }
}
