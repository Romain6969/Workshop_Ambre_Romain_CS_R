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

    private void Start()
    {
        _aim = GameObject.Find("Aim");
        _direction = _aim.transform.position - transform.position;
        _direction.Normalize();
        _rigidBalle.AddForce(_direction * _force);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy" && other.tag != "Bullet" && other.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            Instantiate(_impactPrefab, transform.position, transform.rotation);
            _rigidBalle.AddForce(Vector2.up * (_force * 1.25f));
        }
    }
}
