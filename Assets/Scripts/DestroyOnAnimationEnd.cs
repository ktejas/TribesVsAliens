using UnityEngine;
using System.Collections;

public class DestroyOnAnimationEnd : MonoBehaviour {

    public float animationTime;

	// Use this for initialization
    void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(animationTime); //Took value from Animator Window,Inspector of BallBreak Animation
        Destroy(gameObject);
    }
}
