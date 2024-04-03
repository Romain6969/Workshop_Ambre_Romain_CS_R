using UnityEngine;

public class Ennemie : MonoBehaviour
{
    [SerializeField] private float _walk;
    [SerializeField] private float _speed;
    private float _time;

    public void Update()
    {
        _time += Time.deltaTime;

        if (_time <= _walk)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        
        if (_time >= _walk * 2)
        {
           _time = 0;
        }
    }
}
