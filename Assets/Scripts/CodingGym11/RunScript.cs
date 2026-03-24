using UnityEngine;
using UnityEngine.InputSystem;

public class RunScript : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public AudioSource footstep;
    public AudioClip[] footsteps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = movement;
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void FootStep()
    {
        AudioClip randomStep = footsteps[Random.Range(0, footsteps.Length)];

        footstep.PlayOneShot(randomStep);

    }
}
