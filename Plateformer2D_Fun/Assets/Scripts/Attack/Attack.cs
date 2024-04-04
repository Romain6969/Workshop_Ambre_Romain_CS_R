using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject _balle;
    [SerializeField] private GameObject _spawnBalle;
    [SerializeField] private TransformManager _transformManager;
    private float _reload;
    [field: SerializeField] public bool ReloadReady { get; set; }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && ReloadReady == true)
        {
            Instantiate(_balle, _spawnBalle.transform.position, transform.rotation);
            ReloadReady = false;
        }
    }

    private void FixedUpdate()
    {
        if (ReloadReady == false && _transformManager._wichTransform == 0)
        {
            _reload += Time.deltaTime;
            
            if (_reload >= 0.5f)
            {
                _reload = 0;
                ReloadReady = true;
            }
        }
    }
}
