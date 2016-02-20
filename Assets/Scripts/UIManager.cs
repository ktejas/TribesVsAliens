using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text starText;
    public Text timeText;
    public int time = 140;

    private int minutes;
    private int seconds;
    private bool reachedZero = false;

    void Start ()
    {
        minutes = time / 60;
        seconds = time % 60;
        StartCoroutine(CountDown());
    }
	
	void Update ()
    {
        starText.text = "" + Controller.stars;
        if(seconds < 10)
        {
            timeText.text = "" + minutes + ":0" + seconds;
        }
        else
        {
            timeText.text = "" + minutes + ":" + seconds;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1.0f);
        time--;

        if (time == 0)
        {
            reachedZero = true;
        }
        else
        {
            minutes = time / 60;
            seconds = time % 60;
            StartCoroutine(CountDown());
        }
    }
}
