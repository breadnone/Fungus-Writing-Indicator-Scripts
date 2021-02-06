using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public enum continueAnim
{
    CoinCircle,
    Blink
}
public class continueAnime : MonoBehaviour
{
    public RectTransform continueIcon;
    public GameObject textDots;
    public Writer writer;
    public continueAnim selectEffect = continueAnim.CoinCircle;
    protected Vector3 cacheSiz;
    protected int idd1;
    public float durationOfEachCycle = 0.2f;

    void OnEnable()
    {
        if(continueIcon != null)
        {
            textDots.SetActive(false);
            cacheSiz = continueIcon.sizeDelta;

            if(selectEffect == continueAnim.CoinCircle)
            {
                idd1 = LeanTween.scale(continueIcon, new Vector3(-1f, 1f, 1f), durationOfEachCycle).setLoopPingPong(-1).id;
            }
            if(selectEffect == continueAnim.Blink)
            {
                idd1 = LeanTween.alpha(continueIcon, 0f, durationOfEachCycle).setLoopPingPong(-1).id;
            }
        }
    }
    void OnDisable()
    {
        if(continueIcon != null)
        {
            textDots.SetActive(true);
            LeanTween.cancel(idd1);
            continueIcon.gameObject.transform.localScale = Vector3.one;
            Image b = continueIcon.gameObject.GetComponent<Image>();

            var tempColor = b.color;
            tempColor.a = 1f;
            b.color = tempColor;

            continueIcon.sizeDelta = cacheSiz;            
        }
    }
}
