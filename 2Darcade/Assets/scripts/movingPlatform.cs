using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

    /// <summary>
    /// The platform.
    /// </summary>
    public GameObject platform;

    /// <summary>
    /// The move speed.
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// The current point.
    /// </summary>
    public Transform currentPoint;

    /// <summary>
    /// The points.
    /// </summary>
    public Transform[] points;
   
    /// <summary>
    /// The point selection.
    /// </summary>
    public int pointSelection;

	// Use this for initialization
	void Start () {

        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if(platform.transform.position == currentPoint.position)
        {
            pointSelection++;

            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }

    }
}
