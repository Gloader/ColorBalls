using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	
	public float TranslationSpeed = 10f;
	public float RotationSpeed = 100f;
	public Vector3 direction;
	public Vector3 rotation;
	public KeyCode CameraForward = KeyCode.UpArrow;
	public KeyCode CameraBack = KeyCode.DownArrow;
	public KeyCode CameraLeft = KeyCode.LeftArrow;
	public KeyCode CameraRight = KeyCode.RightArrow;
	public KeyCode CameraUp = KeyCode.PageUp;
	public KeyCode CameraDown = KeyCode.PageDown;
	
	// Use this for initialization
	void Start()
	{
		direction = new Vector3(0, 0, 0);
		rotation = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (direction != Vector3.zero)
		{
			transform.Translate(direction.normalized * TranslationSpeed * Time.deltaTime);
		}
		transform.Rotate(rotation.normalized * RotationSpeed * Time.deltaTime);
	}

	void Update()
	{
		
		Vector3 direction = new Vector3(0, 0, 0);
		Vector3 rotation = new Vector3(0, 0, 0);

		if (Input.GetKey(CameraForward))
		{
			direction.z += 1f;
		}
		if (Input.GetKey(CameraBack))
		{
			direction.z -= 1f;
		}	
		if (Input.GetKey(CameraLeft))
		{
			rotation.y -= 1f;
		}
		if (Input.GetKey(CameraRight))
		{
			rotation.y += 1f;
		}
		if (Input.GetKey(CameraUp))
		{
			rotation.x -= 1f;
		}
		if (Input.GetKey(CameraDown))
		{
			rotation.x += 1f;
		}

		this.direction = direction.normalized;
		this.rotation = rotation.normalized;

	}

}
