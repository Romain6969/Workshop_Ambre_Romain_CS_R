using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject _balle;
    [SerializeField] private GameObject _spawnBalle;
    private float _reload;
    private bool _reloadReady = true;

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && _reloadReady == true)
        {
            Instantiate(_balle, _spawnBalle.transform.position, transform.rotation);
            _reloadReady = false;
        }
    }

    private void FixedUpdate()
    {
        if (_reloadReady == false)
        {
            _reload += Time.deltaTime;
            
            if (_reload >= 0.5f)
            {
                _reload = 0;
                _reloadReady = true;
            }
        }
    }
}
