using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class ToyBoxController : MonoBehaviour
{
    public UnityEvent OnRelease; //event to be hooked up into the inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //challenge 1: single input gate
    public void OnWind(InputAction.CallbackContext context)
    {
        //only trigger when button is released
        if (context.canceled)
        {
            //Debug.Log("Gate passed!"); 
            OnRelease.Invoke(); //calls all modular stuff
        }

    }
}
