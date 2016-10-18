using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Life score.
/// </summary>
public class LifeScore : MonoBehaviour {
	/// <summary>
	/// The text1.
	/// </summary>

	private Text theText1;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		theText1 = GetComponent<Text> ();

	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		theText1.text = "LIFE LEFT: " + LifeManager.lifeCounter;
		//text.text = "" + score;
	}

}