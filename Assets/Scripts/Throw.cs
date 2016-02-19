using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {

	private Animator animator;
	private Animator ballAnim;
	private GameObject ball;
	[HideInInspector]
	public bool triggerEnabled = false;

	void Start ()
	{
		//Controller.instance.activeChar = gameObject;
		animator = GetComponent<Animator> ();
		//ballAnim = GameObject.FindGameObjectWithTag("stone").GetComponent<Animator>();
	}

	void AnimateThrow()
	{
		ball = GameObject.FindGameObjectWithTag ("stone");
		if (ball != null) {
			ballAnim = ball.GetComponent<Animator> ();
			ballAnim.SetInteger ("AnimState", 1);
			animator.SetInteger ("AnimState", 1);
			ball.GetComponent<Trajectory>().enabled=false;
			triggerEnabled = false;
			StartCoroutine (EnableTrigger());
		}
		//animator.SetInteger ("AnimState", 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "stone1") {
			if (triggerEnabled) {
				//Debug.Log ("Entered");
				Controller.instance.activeChar = gameObject;
				triggerEnabled = false;
				other.gameObject.SendMessage ("InstantiateAndDestroyBall");
				//Debug.Log ("Trigger Disabled");
			}
		}
	}

	IEnumerator EnableTrigger()
	{
		yield return new WaitForSeconds(2.0f);
		triggerEnabled=true;
		//Debug.Log ("Trigger Enabled");
	}
}
