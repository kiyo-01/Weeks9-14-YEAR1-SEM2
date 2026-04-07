using UnityEngine;

public class PopUpResponse : MonoBehaviour
{
    public GameObject popUpObject;
    public SpinnerResponse spinner; 
    public float windThreshold = 2.0f;
    //private bool isWoundEnough = false; //didnt end up working like i wanted it to

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //despawn popup immedfaitely
        ResetPopUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //to be called by unity event
    //public void TriggerPop()
    //{
    //    Debug.Log("Popping up!");
    //}

    //called by toybox onrelease
    //public void PrepareToPop(float windTime)
    //{
    //    if (windTime >= windThreshold)
    //    {
    //        isWoundEnough = true;
    //    }
    //    else
    //    {
    //        isWoundEnough = false;
    //    }
    //}

    //called by spinnerresponse onnearstop
    public void SuddenPop()
    {
        if (spinner.windUpTimer >= windThreshold)
        {
            popUpObject.SetActive(true); //abrupt jump up
        }
    }

    public void ResetPopUp()
    {

       popUpObject.SetActive(false);
    }
  }
