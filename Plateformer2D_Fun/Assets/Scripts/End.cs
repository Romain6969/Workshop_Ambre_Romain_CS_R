using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _panel.SetActive(true);
    }
}
