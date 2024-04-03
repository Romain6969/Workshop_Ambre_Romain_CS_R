using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    [field: SerializeField] public float Dammage { get; private set; }

    [SerializeField] private Balle _bulletPrefab;

    public float _hp = 3;

    void Update()
    {
        if (_hp <= 0)
        {
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
