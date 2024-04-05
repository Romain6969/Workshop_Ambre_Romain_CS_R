using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [field: SerializeField] public float Dammage { get; set; }
    [SerializeField] private Rigidbody2D _rigidBalle;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _aim;
    [SerializeField] private GameObject _impactPrefab;
    private Vector2 _direction;
    private bool _scale = false;
    private float _time = 0;

    private void Start()
    {
        _aim = GameObject.Find("Aim");
        _direction = _aim.transform.position - transform.position;
        _direction.Normalize();
        _rigidBalle.AddForce(_direction * _force);
    }

    void Update()
    {
        if (_scale == true)
        {
            _time += Time.deltaTime;

            if (_time >= 0.25f)
            {
                transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                _time = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy" && other.tag != "Bullet" && other.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            Instantiate(_impactPrefab, transform.position, transform.rotation);
            _rigidBalle.AddForce(Vector2.up * (_force * 1.25f));
            _scale = true;
        }
    }
}
