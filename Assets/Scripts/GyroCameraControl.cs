
using UnityEngine;
using UnityEngine.Events;

public class GyroCameraControl : MonoBehaviour 
{
	private Gyroscope gyro;
	private bool gyroSupported;
	private Quaternion rotationFix = new Quaternion (0f, 0f, 1f, 0f);

	public Transform gyroCamera;

	[Tooltip("To Reset GYRO Data.")]
	public bool IsGyroDisabledOnDestroy = false;

	//public UnityEvent OnGyroIsNotSupported;

	void Start () 
	{
		Input.compensateSensors = true;
		Input.gyro.enabled = true;
		gyroSupported = true;//SystemInfo.supportsGyroscope;

		if (gyroSupported) 
		{
			gyroCamera.parent.transform.rotation = Quaternion.Euler (90f, 180f, 0f);

			gyro = Input.gyro;
			gyro.enabled = true;
		}
		else
		{
			//Your Logic
			//OnGyroIsNotSupported.Invoke();
		}
	}

	void Update () 
	{

		//Debug.Log(gyro.attitude);
		if (gyroSupported)
		{

			gyroCamera.localRotation = gyro.attitude* rotationFix;
			Debug.Log(gyroCamera.eulerAngles);
		}
	}

	private void OnDestroy()
	{
		if (gyro != null && IsGyroDisabledOnDestroy)
		{
			gyro.enabled = false;
			//print("Reset Gyro!");
		} 
	}

	public void SetPositionAndRotation (Transform transform)
	{
		//gyroCamera.position  = transform.position;
		gyroCamera.rotation = transform.rotation;
	}

}
