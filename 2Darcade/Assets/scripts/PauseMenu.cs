using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	/// <summary>
	/// The level select.
	/// </summary>
	public string levelSelect;
	/// <summary>
	/// The main menu.
	/// </summary>
	public string mainMenu;

	/// <summary>
	/// The is paused.
	/// </summary>
	public bool isPaused;

	/// <summary>
	/// The pause menu canvas.
	/// </summary>
	public GameObject pauseMenuCanvas;

	/// <summary>
	/// The audiop1.
	/// </summary>
	public AudioSource Audiop1;
	/// <summary>
	/// The audiop2.
	/// </summary>
	public AudioSource Audiop2;
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} 
		else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
			{
			Audiop2.Play ();
				isPaused=!isPaused;
			}
	}

	/// <summary>
	/// Resume this instance.
	/// </summary>
	public void Resume()
	{
		Audiop1.Play ();
		isPaused = false;
	}

	/// <summary>
	/// Levels the select.
	/// </summary>
	/// <returns>The select.</returns>
	public void LevelSelect()
	{
		Audiop1.Play ();
		isPaused = false;
		Score.Reset ();
		SceneManager.LoadScene(levelSelect);
	}

	/// <summary>
	/// Quit this instance.
	/// </summary>
	public void Quit()
	{
		Audiop1.Play ();
		Score.Reset();
		SceneManager.LoadScene (mainMenu);
	}
}
