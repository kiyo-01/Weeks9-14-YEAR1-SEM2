using System.Collections;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1;

    Coroutine theGrowingCoroutine;
    Coroutine theTreeCoroutine;
    Coroutine theAppleCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        appleTransform.localScale = Vector2.zero;
        treeTransform.localScale = Vector2.zero;
        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple()); //will run in parallel

        StartCoroutine(StartTheGrowing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple());
        
        if(theGrowingCoroutine != null)
        {
            StopCoroutine(theGrowingCoroutine);
        }
        
        if (theTreeCoroutine != null)
        {
            StopCoroutine(theTreeCoroutine);
        }
        theTreeCoroutine = StartCoroutine(StartTheGrowing());

        if (theAppleCoroutine != null)
        {
            StopCoroutine(theAppleCoroutine);
        }
    }

    IEnumerator StartTheGrowing()
    {
        Debug.Log("Starting...");
        yield return theTreeCoroutine = StartCoroutine(GrowTree());
        Debug.Log("...tree finished, starting apple...");
        
        //why do this? you can put things in between here, like delays!
        yield return new WaitForSeconds(appleDelay);

        yield return theAppleCoroutine = StartCoroutine(GrowApple());
        Debug.Log("...done!");
    }

    IEnumerator GrowTree()
    {
        float t = 0;
        appleTransform.localScale = Vector2.zero;
        treeTransform.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null; //come back next frame
        }

        yield return new WaitForSeconds(appleDelay); //come back after x seconds

        t = 0;

       
    }

    IEnumerator GrowApple()
    {
        float t = 0;
        appleTransform.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }
    }
}
