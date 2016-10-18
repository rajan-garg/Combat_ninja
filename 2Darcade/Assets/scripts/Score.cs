using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	/// <summary>
	/// The score.
	/// </summary>
	public static int score;
	Text text;

	void Start()
	{
		text = GetComponent<Text> ();
		score += 0;
	}

	void Update()
	{
		text.text = "" + score;
	}

	/// <summary>
	/// Addpoints the specified pointstoadd.
	/// </summary>
	/// <param name="pointstoadd">Pointstoadd.</param>
	public static void Addpoints(int pointstoadd)
	{
		score += pointstoadd;
	}

	/// <summary>
	/// Reset this instance.
	/// </summary>
	public static void Reset()
	{
		score = 0;
	}
}
