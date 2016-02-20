using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public Image loadingBar;

    private float loaded = 0.0f;

	void Start ()
    {
    }
	
	void Update ()
    {
        loaded += 0.01f;
        loadingBar.fillAmount = loaded;
        if(loaded > 1.0f)
        {
            SceneManager.LoadScene(Controller.sceneToLoad);
        }
    }
}
