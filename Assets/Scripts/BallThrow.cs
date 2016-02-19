using UnityEngine;
using System.Collections;

public class BallThrow : MonoBehaviour 
{
	public bool hit = false;
	public GameObject phyBall;
	private Trajectory trajectoryScript;
	private Animator characterAnim;

	void Start()
	{
		trajectoryScript = GetComponent<Trajectory>();
		characterAnim = Controller.instance.activeChar.GetComponent<Animator>();
	}
	
	public void SpawnPhysicsBall()
	{
		//Instantiate (phyBall, new Vector2 (-2.781f, -0.527f), Quaternion.identity);
		//Debug.Log ("BallThrow-SpawnPhysicsBall-Animator-Space");
		characterAnim.SetInteger ("AnimState", 0);
		trajectoryScript.throwBall();
		Destroy (gameObject);
	}
}