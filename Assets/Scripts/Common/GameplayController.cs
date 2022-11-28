using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }
}
