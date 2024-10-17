using UnityEngine;
using UnityEngine.UI;

public class ProductManager : MonoBehaviour {

	public Product[] products;

	public Slider weight, age;

	public void UpdateProductList()
	{
		foreach (var item in products) 
		{
			print (item.name + " " + item.weightGroup + " " + weight.value);

			if(item.weightGroup >= weight.value && item.age >= age.value)
				item.gameObject.SetActive (true);

			else
				item.gameObject.SetActive (false);
		}
	}


}
