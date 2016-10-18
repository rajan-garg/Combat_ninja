using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Bonus score.
/// </summary>
public class BonusScore : MonoBehaviour {

	/// <summary>
	/// The text1.
	/// </summary>
	private Text theText1;

	void Start()
	{
		theText1 = GetComponent<Text> ();

	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		
		int x;
		x = (LifeManager.lifeCounter) * 800;
		theText1.text = "BONUS SCORE: " + x;
		//text.text = "" + score;
	}

}