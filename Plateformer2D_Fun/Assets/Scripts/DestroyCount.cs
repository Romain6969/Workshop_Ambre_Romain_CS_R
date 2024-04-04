using UnityEngine;

public class DestroyCount : MonoBehaviour
{
    private float _time = 0;
    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= 3)
        {
            Destroy(gameObject);
        }
    }
}
