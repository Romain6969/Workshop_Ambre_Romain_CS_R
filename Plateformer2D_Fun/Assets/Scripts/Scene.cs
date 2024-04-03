using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void OnChange()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneName);
    }
}
