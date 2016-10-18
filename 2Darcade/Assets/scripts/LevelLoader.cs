using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	private bool playerZone;
	/// <summary>
	/// The level load.
	/// </summary>
	public string levelLoad;
	/// <summary>
	/// The level tag.
	/// </summary>
	public string levelTag;
	/// <summary>
	/// The audio exit.
	/// </summary>
	public AudioSource AudioExit;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		playerZone = false;
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.W) && playerZone) {
			AudioExit.Play ();
			//LifeManager.increaseLife ();
			PlayerPrefs.SetInt (levelTag, 1);
			SceneManager.LoadScene (levelLoad);
		}
	}
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			playerZone = true;
		}
	}
	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			playerZone = false;
		}
	}
}
