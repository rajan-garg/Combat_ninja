using UnityEngine;
using System.Collections;
/// <summary>
/// Camera follow.
/// </summary>
public class CameraFollow : MonoBehaviour {
	/// <summary>
	/// The x max.
	/// </summary>
	[SerializeField]
	private float xMax;
	/// <summary>
	/// The y max.
	/// </summary>
	[SerializeField]
	private float yMax;
	/// <summary>
	/// The x minimum.
	/// </summary>
	[SerializeField]
	private float xMin;
	/// <summary>
	/// The y minimum.
	/// </summary>
	[SerializeField]
	private float yMin;
	/// <summary>
	/// The target.
	/// </summary>
	private Transform target;

	void Start () {
		target = GameObject.Find ("Player").transform;
	}
	
	/// <summary>
	/// Lates the update.
	/// </summary>
	/// <returns>The update.</returns>
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax),transform.position.z);
	}
}
