using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start ()
	{
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		myRigidbody2D.velocity = new Vector2 (Random.Range(0.1f,0.35f), 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x > 6)
		{
			transform.position = new Vector2 (Random.Range(-10,-6), transform.position.y);
			myRigidbody2D.velocity = new Vector2 (Random.Range (0.1f,0.35f), 0);
		}
	}
}
