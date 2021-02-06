using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class DotsTypeContinueAnim : MonoBehaviour
{
    public Text textDots;
    WaitForSeconds waiting = new WaitForSeconds(0.2f);
    void OnEnable()
    {
        StopAllCoroutines();
        ReCallLoop();
    }
    protected IEnumerator TypingDdot()
    {
        yield return waiting;
        if(textDots.text.Equals("..."))
        {
            textDots.text = "";
        }

        textDots.text = textDots.text + ".";
        ReCallLoop();
        yield break;
      
    }
    protected void ReCallLoop()
    {
        StartCoroutine(TypingDdot());
    }
    void OnDisable()
    {
        textDots.text = "";
    }
}
