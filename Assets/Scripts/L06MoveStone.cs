using UnityEngine;
using System.Collections;

public class L06MoveStone : MonoBehaviour {

    public GameObject movingStone;

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "stone1")
        {
            movingStone.SendMessage("Move");
        }
    }
}
