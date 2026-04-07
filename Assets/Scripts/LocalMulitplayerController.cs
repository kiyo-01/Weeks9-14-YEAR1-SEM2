using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMulitplayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public LocalMultiplayerManager manager;

    public Vector2 movementInput;
    public float speed = 5f;

    public Coroutine activeRoutine;
    public AnimationCurve curve;
    public float aDuration = 0.5f;

    public AudioSource smack;

    public TrailRenderer trail;
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
            manager.PlayerAttacking(playerInput);
            Debug.Log("ATTACKING");

            
            if (activeRoutine != null) StopCoroutine(activeRoutine);
            activeRoutine = StartCoroutine(AttackRoutine());
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
            if(activeRoutine != null) StopCoroutine(activeRoutine);
            activeRoutine = StartCoroutine(DashRoutine()); 
    }

    IEnumerator AttackRoutine()
    {
        float elapsed = 0f;
        Vector3 initialScale = Vector3.one;

        smack.Play();
        while (elapsed < aDuration)
        {
            elapsed += Time.deltaTime;
            float scaleMultiplier = curve.Evaluate(elapsed / aDuration);
            //transform.localScale = initialScale * (1f + scaleMultiplier);
            transform.localScale = new Vector3(initialScale.x, initialScale.y * (1f - scaleMultiplier), initialScale.z);
            yield return null;
        }
    }    

    IEnumerator DashRoutine()
    {
        float t = 0f;
        while (t < 1)
        {
            speed = 20f;
            trail.emitting = true;
            t += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f); //dash duration

        speed = 5f;
        t = 0f;
        trail.emitting = false;
    }
}
