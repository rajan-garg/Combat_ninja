using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbar : MonoBehaviour{

	/// <summary>
	/// The fill amount.
	/// </summary>
	private float fillAmount;

	[SerializeField]
	private float lerpspeed;
	/// <summary>
	/// The content.
	/// </summary>
	[SerializeField]
	private Image content;
	/// <summary>
	/// The value text.
	/// </summary>
	[SerializeField]
	private Text valueText;
	/// <summary>
	/// The fullcolor.
	/// </summary>
	[SerializeField]
	private Color fullcolor;
	/// <summary>
	/// The lowcolor.
	/// </summary>
	[SerializeField]
	private Color lowcolor;
	/// <summary>
	/// The lerp colors.
	/// </summary>
	[SerializeField]
	private bool lerpColors;

	/// <summary>
	/// Gets or sets the max value.
	/// </summary>
	/// <value>The max value.</value>
	public float MaxValue{ get; set;}

	/// <summary>
	/// Sets the value.
	/// </summary>
	/// <value>The value.</value>
	public float Value
	{
		
		set
		{
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp [0] + ":" + value;
			fillAmount = Map (value, 0, MaxValue, 0, 1);	
		}

	}

	/// <summary>
	/// Start this instance.
	/// </summary>

	void Start()
	{
		if (lerpColors) 
		{
			content.color = fullcolor;		
		}


	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		HandleBar ();
	}
	/// <summary>
	/// Handles the bar.
	/// </summary>
	/// <returns>The bar.</returns>
	private void HandleBar()
	{
		if (fillAmount != content.fillAmount) 
		{
			content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount, Time.deltaTime *lerpspeed);
		}
		if (lerpColors) 
		{
			content.color = Color.Lerp (lowcolor, fullcolor, fillAmount);
		}

	}
	/// <summary>
	/// Map the specified value, inMin, inMax, outMin and outMax.
	/// </summary>
	/// <param name="value">Value.</param>
	/// <param name="inMin">In minimum.</param>
	/// <param name="inMax">In max.</param>
	/// <param name="outMin">Out minimum.</param>
	/// <param name="outMax">Out max.</param>
	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}