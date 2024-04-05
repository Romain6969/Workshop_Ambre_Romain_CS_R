using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _ooofPrefab;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _gameOverPanel.SetActive(true);
            Instantiate(_ooofPrefab, transform.position, transform.rotation);
            Destroy(GameObject.Find("Players"));
        }
    }
}
