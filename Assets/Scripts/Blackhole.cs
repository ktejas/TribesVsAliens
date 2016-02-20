using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour
{

    public float xPos = 2.011f;
    public float yPos = 2.385f;
    public GameObject otherHole;

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
            other.transform.position = new Vector2(xPos, yPos);
            otherHole.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(ActivateOtherHoleCollider());
        }
    }

    IEnumerator ActivateOtherHoleCollider()
    {
        yield return new WaitForSeconds(0.5f);
        otherHole.GetComponent<CircleCollider2D>().enabled = true;
    }
}
