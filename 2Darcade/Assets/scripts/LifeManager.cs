using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	/// <summary>
	/// The starting lives.
	/// </summary>
	public int startingLives;
	/// <summary>
	/// The life counter.
	/// </summary>
	public static int lifeCounter;
	Text theText;
	/// <summary>
	/// The temp.
	/// </summary>
	public static int temp;
	/// <summary>
	/// The game over load.
	/// </summary>
	public string gameOverLoad;

	// Use this for initialization
	void Start () {

		theText = GetComponent <Text> ();
		if(Score.score==0)
		lifeCounter = startingLives;

	}



	// Update is called once per frame
	void Update () {
		theText.text = "x " + lifeCounter;
		if (lifeCounter <= 0)
		{

			SceneManager.LoadScene(gameOverLoad);
		}
	}

	/// <summary>
	/// Decreases the life.
	/// </summary>
	/// <returns>The life.</returns>
	public static void decreaseLife()
	{
	 lifeCounter -= 1;

	}

	/// <summary>
	/// Increases the life.
	/// </summary>
	/// <returns>The life.</returns>
	public static void increaseLife()
	{
		lifeCounter += 1;
	}
}
