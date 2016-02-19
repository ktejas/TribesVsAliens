using UnityEngine;
using System.Collections;

public class PhysicsBall : MonoBehaviour {

	private Rigidbody2D myRigidbody2D;
	public GameObject ball;
	public GameObject ballBreakAnim;
	private GameObject character;
	
	void Start()
	{
		character =  GameObject.FindGameObjectWithTag ("Player");
		//forceX = 55 + Random.Range(-10,10);
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		//myRigidbody2D.AddForce(new Vector2(forceX,forceY));
		StartCoroutine (Stopped());
	}
	
	void Update()
	{
		if (transform.position.x > 10.0f ||
		    transform.position.x < -10.0f ||
		    transform.position.y > 10.0f ||
		    transform.position.y < -10.0f )
		{
			InstantiateAndDestroyBall();
		}
	}

	void InstantiateBall()
	{
		Instantiate (ball, new Vector2 (character.transform.position.x+3.142f,character.transform.position.y+0.998f),Quaternion.identity);
	}

	void InstantiateAndDestroyBall()
	{
		InstantiateBall ();
        //if(character.GetComponent<Throw>())
        //{
            character.GetComponent<Throw>().triggerEnabled = false;
        //}
        //else
        //{
        //    character.GetComponent<Throw2>().triggerEnabled = false;
        //}
		Controller.instance.activeChar = character;
		//Debug.Log ("Trigger Disabled by Destruction");
		Destroy (gameObject);
	}
	
	IEnumerator Stopped()
	{
		yield return new WaitForSeconds(1.0f);
		while (myRigidbody2D.velocity.magnitude > 0.001)
		{
			yield return new WaitForEndOfFrame();
		}
		Instantiate (ballBreakAnim, transform.position, Quaternion.identity);
		InstantiateAndDestroyBall ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "totem")
		{
			coll.gameObject.SendMessage("ApplyDamage",1);        
			Instantiate (ballBreakAnim, transform.position, Quaternion.identity);
			InstantiateAndDestroyBall ();
		}
		if (coll.gameObject.tag == "spike")
		{
			Instantiate (ballBreakAnim, transform.position, Quaternion.identity);
			InstantiateAndDestroyBall ();
		}
	}
}