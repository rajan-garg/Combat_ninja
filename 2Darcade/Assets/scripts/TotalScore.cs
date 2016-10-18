using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Total score.
/// </summary>
public class TotalScore : MonoBehaviour {


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
		x = ((LifeManager.lifeCounter) * 800) + Score.score;
		theText1.text = "TOTALSCORE: " + x;
		//text.text = "" + score;
	}

}