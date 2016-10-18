using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// Class represents the Select level screen manager
/// </summary>
public class LevelSelectManager : MonoBehaviour {

	/// <summary>
	/// The level tags.
	/// </summary>
	public string[] levelTags;
	/// <summary>
	/// The locks on level.
	/// </summary>
	public GameObject[] locks;
	/// <summary>
	/// The level unlocked.
	/// </summary>
	public bool[] levelUnlocked;

	/// <summary>
	/// The position selector.
	/// </summary>
	public int positionSelector;
	/// <summary>
	/// The distance below lock.
	/// </summary>
	public float distanceBelowLock;
	/// <summary>
	/// The name of the level.
	/// </summary>
	public string[] levelName;
	/// <summary>
	/// The move speed.
	/// </summary>
	public float moveSpeed;
	private bool isPressed;

	/// <summary>
	/// The audio sel1.
	/// </summary>
	public AudioSource AudioSel1;
	/// <summary>
	/// The audio sel2.
	/// </summary>
	public AudioSource AudioSel2;
	int i;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{


		for ( i = 0; i < levelTags.Length; i++)
		{
			if (i != (levelTags.Length - 1)) 
			{
				
				if (PlayerPrefs.GetInt (levelTags [i]) == 0) {
					levelUnlocked [i] = false;
				} else if (PlayerPrefs.GetInt (levelTags [i]) == 0) {
					levelUnlocked [i] = false;
				} else {
					levelUnlocked [i] = true;
				}
				if (levelUnlocked [i]) {
					locks [i].SetActive (false);
				}
			}

		}
		positionSelector = PlayerPrefs.GetInt ("PlayerLevelSelectPosition");
		transform.position = locks [positionSelector].transform.position + new Vector3 (0, distanceBelowLock, 0);
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()

	{
		if (!isPressed) {
			if (Input.GetAxis ("Horizontal") > 0.25f) {
				if(positionSelector!=levelTags.Length-1)
					AudioSel2.Play ();
				positionSelector += 1;
				isPressed = true;

			}	
			if (Input.GetAxis ("Horizontal") < -0.25f) {
				if(positionSelector!=0)
					AudioSel2.Play ();
				positionSelector -= 1;
				isPressed = true;

			}	
			if (positionSelector >= levelTags.Length) {
				//positionSelector = levelTags.Length - 1;
				positionSelector = levelTags.Length-1;
			}
			if (positionSelector < 0) {
				positionSelector = 0;
			}

		}
		if (isPressed) {
			if (Input.GetAxis ("Horizontal") < 0.25f && Input.GetAxis ("Horizontal") > -0.25f) {
				isPressed = false;
			}
			}


		transform.position = Vector3.MoveTowards (transform.position, locks [positionSelector].transform.position + new Vector3 (0, distanceBelowLock, 0), moveSpeed * Time.deltaTime);
		if ( Input.GetKeyDown (KeyCode.Space)||  Input.GetKeyDown (KeyCode.Z)) 
		{

			if (positionSelector != (levelTags.Length-1))
			{
				if (levelUnlocked [positionSelector])
				{
					AudioSel1.Play ();
					PlayerPrefs.SetInt ("PlayerLevelSelectPosition",positionSelector);
					SceneManager.LoadScene (levelName [positionSelector]);
				}	
			}
			else if (positionSelector == (levelTags.Length-1)) 
			{
				AudioSel1.Play ();
				for (i = 1; i < levelTags.Length; i++)
				{
					//if (PlayerPrefs.GetInt (levelTags [i]) == null);
					//PlayerPrefs.GetInt (levelTags [i]) =null; 
					PlayerPrefs.SetInt (levelTags[i], 0);
					levelUnlocked [i] = false;
					locks [i].SetActive (true);
				}
				//	Application.LoadLevel (levelName[positionSelector]);
			}
		}
	}

}
