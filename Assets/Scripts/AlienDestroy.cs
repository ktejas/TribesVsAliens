using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AlienDestroy : MonoBehaviour {

    private SpriteRenderer sprRen;
    public Sprite[] healthSprites;
    private int animState = 0;
    public GameObject totemDestroyAnim;

    void Start()
    {
        sprRen = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void ApplyDamage(int i)
    {
        if (animState < healthSprites.Length)
        {
            Instantiate(totemDestroyAnim, transform.position + new Vector3(0.0f, 0.34f, 0.0f), Quaternion.identity);
            animState += i;
            if (animState == healthSprites.Length - 1)
            {
                //Application.LoadLevel("Levels");
                SceneManager.LoadScene("Levels");
            }
            else
            {
                sprRen.sprite = healthSprites[animState];
            }

            /*
			//Regenerate Polygon Collider as per the changed sprite
			Destroy (GetComponent<PolygonCollider2D> ());
			gameObject.AddComponent<PolygonCollider2D> ();
			*/
        }
    }
}
