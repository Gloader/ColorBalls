using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{
	Camera MainCamera;
	bool isSelected = false;

	// Use this for initialization
	void Start()
	{
		MainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update()
	{
		Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown(0))
		{
			isSelected = false;
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.collider == collider)
				{
					isSelected = true;
				}
			}			
		}

		if (Input.GetMouseButtonUp(0))
		{
			if ((isSelected) && (Physics.Raycast(ray, out hit, 100)))
			{
				GetComponent<NavMeshAgent>().SetDestination(hit.point);
				Debug.DrawLine(ray.origin, hit.point);
			}
			isSelected = false;
		}



	}
}
