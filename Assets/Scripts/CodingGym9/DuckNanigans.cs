using UnityEngine;
using UnityEngine.InputSystem;

public class DuckNanigans : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        transform.eulerAngles += direction * 20 * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
        direction.z = context.ReadValue<Vector2>().x;
        transform.eulerAngles = direction;
    }
}
