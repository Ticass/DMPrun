using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    public Text text;
    private string test; 
    private string[] token;
    public string TextToDisplay;

    void Start(){
        StartCoroutine(Wait());
        test = TextToDisplay;
    }


    void Awake(){

    }

    IEnumerator Wait()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
       yield return new WaitForSeconds(1);

        
        foreach (char r in test){
        yield return new WaitForSeconds((float)0.15);
        text.text += r.ToString();
       }
    }


    // Update is called once per frame
    void Update()
    {
       
        
    }
}
