using UnityEngine;
using UnityEngine.InputSystem;

public class Transformation : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _transform;
    [SerializeField] private TransformManager _transformManager;
    [SerializeField] private Attack _attack;
    [SerializeField] private Jump _jump;
    [SerializeField] private Movement _movement;

    private void Start()
    {
        _transformManager = FindObjectOfType<TransformManager>();
        _jump.Time = 2;
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
        _jump.Time += Time.deltaTime;

        if (_transformManager._wichTransform == 0)
        {
            _jump.Height = 7.5f;
            _jump.MaxTime = 1.6f;
            _movement.Speed = 5;

            if (_transformManager._canAppear == true)
            {
                _transformManager._canAppear = false;
                _transform.SetActive(false);
                _player.SetActive(true);
            }
        }
        else if (_transformManager._wichTransform == 1)
        {
            _attack.ReloadReady = false;
            _jump.Height = 5f;
            _jump.MaxTime = 0.9f;
            _movement.Speed = 10;

            if (_transformManager._canAppear == false)
            {
                _transformManager._canAppear = true;
                _player.SetActive(false);
                _transform.SetActive(true);
            }
        }
        else if (_transformManager._wichTransform >= 2)
        {
            _transformManager._wichTransform = 0;
        }
    }
}
