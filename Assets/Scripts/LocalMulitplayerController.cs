using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMulitplayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public LocalMultiplayerManager manager;

    public Vector2 movementInput;
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Attacking!");
            manager.PlayerAttacking(playerInput);
        }
    }
}
