using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	/// <summary>
	/// The start level.
	/// </summary>
	public string startLevel;

	/// <summary>
	/// The level select.
	/// </summary>
	public string levelSelect;

	/// <summary>
	/// The level1 tag.
	/// </summary>
	public string level1Tag;

	/// <summary>
	/// News the game.
	/// </summary>
	/// <returns>The game.</returns>
	public void NewGame()
	{
		GetComponent <AudioSource> ().Play ();
		PlayerPrefs.SetInt (level1Tag,1	);
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		Score.Reset();
		SceneManager.LoadScene (startLevel);

	}

	/// <summary>
	/// Levels the select.
	/// </summary>
	/// <returns>The select.</returns>
	public void LevelSelect()
	{
		GetComponent <AudioSource> ().Play ();
		PlayerPrefs.SetInt (level1Tag,1	);
		if (!PlayerPrefs.HasKey ("PlayerLevelSelectPosition")) 
		{
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		}
		Score.Reset();
		SceneManager.LoadScene(levelSelect);
		SceneManager.LoadScene(levelSelect);
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	/// <returns>The game.</returns>
	public void QuitGame()
	{
		GetComponent <AudioSource> ().Play ();
		Score.Reset() ;
		Application.Quit ();
	}
}
