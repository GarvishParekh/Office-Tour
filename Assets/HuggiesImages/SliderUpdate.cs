using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour {

	public Slider slider;
	public Text weight;

	public Text[] ages;

	public Color yellow;

	public void UpdateWeightValue()
	{
		weight.text = slider.value.ToString () + "KG";
	}

	public void UpdateAge()
	{
		for (int i = 0; i < ages.Length; i++) 
		{
			if(i == slider.value)
			{
				ages[i].color = yellow;
			}
			
			else
			{
				ages[i].color = Color.white;
			}
		}
	}
}

