using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;

    void Update()
    {
        Vector3 newPosition = _player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

}
