using UnityEngine;

public class OpenLink : MonoBehaviour {

	public void Open(string link)
	{
		Application.OpenURL ("https://www.huggies.com.my/en-my/auth/try-a-sample");
	}
}
