using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelsGUI : MonoBehaviour {

	public int level = 1;
	
	void OnMouseUpAsButton()
	{
        //Application.LoadLevel ("Level"+level);
        SceneManager.LoadScene("Level" + level);
	}

	/*void OnGUI(){
		if (GUI.Button(new Rect(Screen.width / 3 - 250, Screen.height * 0.5f, 250, 150), "Level 1"))
			Application.LoadLevel("Level01");
		if (GUI.Button(new Rect(Screen.width / 3 + 320 - 250, Screen.height * 0.5f, 250, 150), "Level 2"))
			Application.LoadLevel("Level02");
		if (GUI.Button(new Rect(Screen.width / 3 + 640 - 250, Screen.height * 0.5f, 250, 150), "Level 3"))
			Application.LoadLevel("Level03");
	}*/
}
