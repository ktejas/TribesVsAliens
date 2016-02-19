using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TotemDestroy : MonoBehaviour
{
	private SpriteRenderer sprRen;
	public Sprite [] spr;
	private int animState = 0;
    public GameObject totemDestroyAnim;

	void Start ()
	{
		sprRen = GetComponent<SpriteRenderer> ();
		sprRen.sprite = spr [animState];
	}

	void Update ()
	{

	}
	
	void ApplyDamage(int i)
	{
		if (animState < 5)
        {
            Instantiate(totemDestroyAnim, transform.position + new Vector3(0.0f,0.34f,0.0f), Quaternion.identity);
			animState += i;
			if(animState==5) SceneManager.LoadScene("Levels"); //Application.LoadLevel ("Levels");
			sprRen.sprite = spr [animState];

			/*
			//Regenerate Polygon Collider as per the changed sprite
			Destroy (GetComponent<PolygonCollider2D> ());
			gameObject.AddComponent<PolygonCollider2D> ();
			*/
		}
	}
}