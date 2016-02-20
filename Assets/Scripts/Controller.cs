using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public static Controller instance;
	public Transform ball;
	public GameObject activeChar;
    public static string sceneToLoad = "Levels";

	void Awake()
	{
		instance = this;
	}

	void Start ()
	{
        StartCoroutine(SetActiveChar());
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.R))
		{
			//Application.LoadLevel (Application.loadedLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

		if(Input.GetKey (KeyCode.Escape))
		{
            SceneManager.LoadScene("Levels");
			//Application.LoadLevel ("Levels");
			//Application.Quit();
		}
	}

    private IEnumerator SetActiveChar()
    {
        yield return new WaitForSeconds(0.1f);
        activeChar = GameObject.FindGameObjectWithTag("Player");
    }
}
