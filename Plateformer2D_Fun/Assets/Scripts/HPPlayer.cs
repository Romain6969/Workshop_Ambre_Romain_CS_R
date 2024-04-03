using UnityEngine;

public class HPPlayer : MonoBehaviour
{
    [SerializeField] private HPEnemy _enemyPrefab;

    private float _invulnerability = 0;
    private float _hp = 5;

    void Update()
    {
        _invulnerability += Time.deltaTime;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_invulnerability >= 1.5f)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _hp -= _enemyPrefab.Dammage;
            }
        }
    }
}
