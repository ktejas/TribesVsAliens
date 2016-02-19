using UnityEngine;
using System.Collections;

public class BallBreak : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Destroy());
	}

	private IEnumerator Destroy()
	{
		yield return new WaitForSeconds(0.583f); //Took value from Animator Window,Inspector of BallBreak Animation
		Destroy(gameObject);
	}
}
