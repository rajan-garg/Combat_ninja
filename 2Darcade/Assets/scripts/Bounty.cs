using UnityEngine;
using System.Collections;

public class Bounty : MonoBehaviour {
	/// <summary>
	/// The audio1.
	/// </summary>
	public AudioSource Audio1;
	/// <summary>
	/// The pointstoadd.
	/// </summary>
	public int pointstoadd;
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="Player") 
		{
			Score.Addpoints (pointstoadd);
			Destroy (gameObject); 
			Audio1.Play ();
		}
	}
}
