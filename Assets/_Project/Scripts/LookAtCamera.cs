using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	Camera cameraToLookAt;
	Transform cameraTransform;
	Transform thisTransform;

	private void Awake()
	{
		cameraToLookAt = Camera.main;
		cameraTransform = cameraToLookAt.transform;
		thisTransform = transform;
	}

	private void Update()
	{
		LookCamera();
	}

	private void LookCamera()
	{
		thisTransform.rotation = cameraTransform.rotation;
	}
}
