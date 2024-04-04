using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
        }
    }
}
