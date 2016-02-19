using UnityEngine;
using System.Collections;

public class Throw2 : MonoBehaviour {
	
	private Animator animator;
	private Animator ballAnim;
	private GameObject ball;
    [HideInInspector]
    public bool triggerEnabled = true;
	public GameObject animationBall;
	private GameObject ballParent;
	
	void Start ()
	{
		animator = GetComponent<Animator> ();
		//animBallInstance = GameObject.FindGameObjectWithTag("BallParent").GetComponent<Animator>();
	}
	
	void AnimateThrow()
	{
		ball = GameObject.FindGameObjectWithTag ("stone");
		//animBallInstance.transform.localScale = new Vector2(-1.0f,1.0f);
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
				Controller.instance.activeChar = this.gameObject;
				triggerEnabled = false;
				ballParent = (GameObject) Instantiate (animationBall, new Vector2 (transform.position.x-3.142f,transform.position.y+0.998f),Quaternion.identity); //animBallInstance = (GameObject)
				ballParent.transform.localScale = new Vector2(-1.0f,1.0f);
				Destroy (other.gameObject);
			}
		}
	}
	
	IEnumerator EnableTrigger()
	{
		yield return new WaitForSeconds(2.0f);
		triggerEnabled=true;
		//Debug.Log ("Trigger 2 Enabled");
	}
}
