using System.Collections;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    private Vector3 ogPos;
    private Coroutine shakeRoutine;

    public float shakeAmount = 0.05f; //how far it offsets
    public float shakeSpeed = 50f; //how fast it shakes

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //store starting location to return to it
        ogPos = transform.localPosition; //localpos seems to work better than just pos, since pos was making the box shake independently from the spinner and popup.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartShaking()
    {
        //if active, restart it 
        if (shakeRoutine != null) StopCoroutine(shakeRoutine);
        shakeRoutine = StartCoroutine(ShakeRoutine());
    }

    public void StopShaking()
    {
        if (shakeRoutine != null) StopCoroutine(shakeRoutine);
        //reset to same spot
        transform.localPosition = ogPos;
    }

    IEnumerator ShakeRoutine()
    {
        while(true)
        {
            //calculate tiny offset for shakes
            float offsetX = Random.Range(-1f, 1f) * shakeAmount;
            float offsetY = Random.Range(-1f, 1f) * shakeAmount;

            transform.localPosition = ogPos + new Vector3(offsetX, offsetY, 0f);

            //wait logic from coroutine video
            yield return new WaitForSeconds(1f / shakeSpeed);
        }
    }
}
