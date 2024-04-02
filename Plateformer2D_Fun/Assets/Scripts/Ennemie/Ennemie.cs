using UnityEngine;

public class Ennemie : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _time;

    private void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_time <= 1)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        if(_time > 1)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            _time = 0;
        }

    }
}
