using UnityEngine;
using System.Collections;

public class L04WoodCollision : MonoBehaviour {

    Animator a;

    void Start()
    {
        a = GetComponent<Animator>();
        a.speed = 0.0f;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "stone1")
        {
            a.speed = 1.0f;
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.667f); //Took value from Animator Window,Inspector of BallBreak Animation
        Destroy(gameObject);
    }
}