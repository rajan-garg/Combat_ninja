using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {


	/// <summary>
	/// The lifetime.
	/// </summary>
	public float lifetime;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		lifetime -= Time.deltaTime;

		if (lifetime < 0) 
		{
			Destroy (gameObject);
		}
	}
}
