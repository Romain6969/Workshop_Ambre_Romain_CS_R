using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBalle;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _aim;
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
        if (other.tag != "Ennemie" && other.tag != "Balle")
        {
            Destroy(gameObject);
        }
    }
}