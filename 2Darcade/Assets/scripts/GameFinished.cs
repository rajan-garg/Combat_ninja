using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Game finished.
/// </summary>
public class GameFinished : MonoBehaviour {

	/// <summary>
	/// The text2.
	/// </summary>
	private Text theText2;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		theText2 = GetComponent<Text> ();

	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		theText2.text = "GAMESCORE: " + Score.score;
		//text.text = "" + score;
	}

}