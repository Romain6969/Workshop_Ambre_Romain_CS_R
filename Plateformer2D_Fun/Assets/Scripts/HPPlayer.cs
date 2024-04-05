using UnityEngine;
using TMPro;
using DG.Tweening;

public class HPPlayer : MonoBehaviour
{
    [SerializeField] private HPEnemy _enemyPrefab;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _ooofPrefab;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _force;
    [SerializeField] private Movement _movement;
    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private AudioClip _ouch;
    private float _invulnerability = 0.5f;
    private float _hp = 5;

    void Update()
    {
        _text.text = $"Life : {_hp}";

        _invulnerability += Time.deltaTime;

        if (_hp <= 0)
        {
            Instantiate(_ooofPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            _gameOverPanel.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_invulnerability >= 1.5f)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _audiosource.PlayOneShot(_ouch);
                _hp -= _enemyPrefab.Dammage;
                _invulnerability = 0;

                // Shake the camera when hit.
                CameraShake.Shake(0.5f, 1f);

                // Calculate Angle Between the collision point and the player
                ContactPoint2D contactPoint = collision.GetContact(0);
                Vector2 playerPosition = new Vector2(transform.position.x, 2f);
                Vector2 dir = contactPoint.point - playerPosition;

                // We then get the opposite (-Vector3) and normalize it
                dir = -dir.normalized;

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().inertia = 0;

                //If the problme is not resolved then lock controle key. "playerControles" is a public static boolean which you have declare in the player controller script with true. then in this script you have to enable it or disable it.like
                _movement.PlayerController = false; //if its true player input buttons will work and vice versa.
                Invoke("EnablePlayerControles", 1f); //if then amount of time is long then reduce it to the value you want.

                // And finally we add force in the direction of dir and multiply it by force. 
                // This will push back the player
                GetComponent<Rigidbody2D>().AddForce(dir * _force, ForceMode2D.Impulse);
            }
        }
    }
    private void EnablePlayerControles()
    {
        _movement.PlayerController = true;
    }
}
