using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _gameOverPanel.SetActive(true);
            Destroy(GameObject.Find("Players"));
        }
    }
}
