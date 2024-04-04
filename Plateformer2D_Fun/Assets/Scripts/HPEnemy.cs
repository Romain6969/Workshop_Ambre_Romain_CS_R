using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    [field: SerializeField] public float Dammage { get; private set; }

    [SerializeField] private Balle _bulletPrefab;
    [SerializeField] private GameObject _explosionPrefab;

    private float _hp = 3;

    void Update()
    {
        if (_hp <= 0)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp -= _bulletPrefab.Dammage;
        }
    }
}
