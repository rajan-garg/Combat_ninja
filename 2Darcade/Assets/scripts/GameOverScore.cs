using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Score displayed on the screen after gameover
/// </summary>
public class GameOverScore : MonoBehaviour {


	private Text theText1;

	void Start()
	{
		theText1 = GetComponent<Text> ();

	}
	/// <summary>
	/// Score gets updated.
	/// </summary>
	void Update()
	{
		theText1.text = "GAMESCORE: " + Score.score;
		//text.text = "" + score;
	}

}