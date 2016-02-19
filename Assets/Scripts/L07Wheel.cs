using UnityEngine;
using System.Collections;

public class L07Wheel : MonoBehaviour {

	void Start ()
	{

	}

	void Update ()
	{
		transform.Rotate(0, 0, 150 * Time.deltaTime);
	}
}
