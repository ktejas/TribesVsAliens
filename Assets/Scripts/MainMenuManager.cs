using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private float loaded = 0.0f;

    void Start ()
    {
	
	}
	
	void Update ()
    {
        loaded += 0.01f;
        if (loaded > 1.0f)
        {
            SceneManager.LoadScene("Levels");
        }
    }
}
