using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpinnerResponse : MonoBehaviour
{
    private Coroutine activeRoutine;
    public UnityEvent OnNearStop;
    public float windUpTimer = 0f;

    //settings
    public float slowWindSpeed = 50f;
    public float releaseMultiplier = 200f;

    public float popThreshold = 40f; //the speed at which the spin slows down to which triggers the pop


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call by onwind event
    public void StartWinding()
    {
        //stop old one and start new one
        if (activeRoutine != null) StopCoroutine(activeRoutine);
        activeRoutine = StartCoroutine(WindingRoutine());
    }
    //called by onrelease event
    public void StopWindingRelease()
    {
        //same as above
        if (activeRoutine != null) StopCoroutine(activeRoutine);
        activeRoutine = StartCoroutine(ReleaseRoutine());
    }

    public void ResetSpinner()
    {
        if (activeRoutine !=null) StopCoroutine(activeRoutine);
        windUpTimer = 0f;
        //snap back to zero
        transform.eulerAngles = Vector3.zero;
    }

    IEnumerator WindingRoutine()
    {
        windUpTimer = 0f; //reset charge

        while(true) //runs until controller stops it
        {
            windUpTimer += Time.deltaTime; //increments while held

            //spin slowly in one direction on z
            Vector3 rot = transform.eulerAngles;
            rot.z -= slowWindSpeed * Time.deltaTime;
            transform.eulerAngles = rot;

            yield return null;
        }
    }


    IEnumerator ReleaseRoutine()
    {
        //calc starting speed based on how long it was held
        float currentSpeed = windUpTimer * releaseMultiplier;
        float decel = 100f;
        bool hasPopped = false;

        while (currentSpeed > 0.1f)
        {
            //spin in other direction on z
            Vector3 rot = transform.eulerAngles;
            rot.z += currentSpeed * Time.deltaTime;
            transform.eulerAngles = rot;

            currentSpeed -= decel * Time.deltaTime;

            //signal to pop right before we stop!
            if (!hasPopped && currentSpeed < popThreshold)
            {
                OnNearStop.Invoke();
                hasPopped = true;
            }

            yield return null;
        }    
    }

}
