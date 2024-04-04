using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [field: SerializeField] public float Dammage { get; set; }
    [SerializeField] private Rigidbody2D _rigidBalle;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _aim;
    [SerializeField] private GameObject _vFXgraph;
    private Vector2 _direction;
    private bool _isActive = false;
    private float _time;

    private void Start()
    {
        _aim = GameObject.Find("Aim");
        _direction = _aim.transform.position - transform.position;
        _direction.Normalize();
        _rigidBalle.AddForce(_direction * _force);
    }

    void Update()
    {
        if (_isActive == true)
        {
            _time += Time.deltaTime;

            if (_time >= 0.2f)
            {
                _vFXgraph.SetActive(false);
                _time = 0;
                _isActive = false;
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
            _vFXgraph.SetActive(true);
            _rigidBalle.AddForce(Vector2.up * (_force * 1.25f));
            _isActive = true;
        }
    }
}
