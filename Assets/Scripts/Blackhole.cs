using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour
{

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "stone1")
        {
            other.transform.position = new Vector2(2.011f, 2.385f);
        }
    }
}
