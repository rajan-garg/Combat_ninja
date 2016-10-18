using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Stat.
/// </summary>
[Serializable]
public class stat 
{/// <summary>
/// The bar.
/// </summary>
	[SerializeField]
	private healthbar bar;
	/// <summary>
	/// The max value.
	/// </summary>
	[SerializeField]
	private float maxVal;
	/// <summary>
	/// The current value.
	/// </summary>
	[SerializeField]
	private float currentVal;

	/// <summary>
	/// Gets or sets the current value.
	/// </summary>
	/// <value>The current value.</value>
	public float CurrentVal
	{
		get 
		{ 
			return currentVal;
		}
		set 
		{
			this.currentVal = Mathf.Clamp(value,0,MaxVal);
			bar.Value = currentVal;
		}

	}
	/// <summary>
	/// Gets or sets the max value.
	/// </summary>
	/// <value>The max value.</value>
	public float MaxVal
	{
		get
		{
			return maxVal;
		}
		set
		{
			this.maxVal = value;
			bar.MaxValue= maxVal;

		}
	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public void Initialize()
	{
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	}

}
