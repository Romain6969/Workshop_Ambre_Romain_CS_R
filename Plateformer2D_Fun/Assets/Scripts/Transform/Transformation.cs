using UnityEngine;
using UnityEngine.InputSystem;

public class Transformation : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _transform;
    private bool _canTransform = true;
    [SerializeField] private TransformManager _transformManager;

    private void Start()
    {
        _transformManager = FindObjectOfType<TransformManager>();
    }
    public void OnTransform(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _transformManager._wichTransform += 1;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(_transformManager._wichTransform);
        Debug.Log(_transformManager._canAppear);
        if (_transformManager._wichTransform == 0)
        {
            if (_transformManager._canAppear == true)
            {
                _transformManager._canAppear = false;
                Destroy(GameObject.Find("PlayerTransformation(Clone)"));
                Destroy(GameObject.Find("PlayerTransformation(Clone)(Clone)"));
                Instantiate(_player);
            }
        }
        else if (_transformManager._wichTransform == 1)
        {
            if (_transformManager._canAppear == false)
            {
                _transformManager._canAppear = true;
                Destroy(GameObject.Find("Player"));
                Destroy(GameObject.Find("Player(Clone)"));
                Instantiate(_transform);
            }
        }
        else if (_transformManager._wichTransform >= 2)
        {
            _transformManager._wichTransform = 0;
        }
    }
}
