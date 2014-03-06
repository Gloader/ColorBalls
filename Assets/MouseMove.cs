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
		Ray ray;
		RaycastHit hit;

		if (Input.GetMouseButtonDown(0))
		{
			ray = MainCamera.ScreenPointToRay(Input.mousePosition);
			isSelected = false;
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.collider == collider)
				{
					isSelected = true;
				}
			}			
		} else
		if (Input.GetMouseButtonUp(0))
		{
			ray = MainCamera.ScreenPointToRay(Input.mousePosition);
			if ((isSelected) && (Physics.Raycast(ray, out hit, 100)))
			{
				if (hit.collider.tag == "Ground")
				{
					GetComponent<NavMeshAgent>().SetDestination(hit.point);
					//Debug.DrawLine(ray.origin, hit.point);
				} else if (hit.collider.tag == "Hero")
				{
					GameObject gameObject;
					gameObject = (GameObject)Instantiate(Resources.Load<GameObject>("Link"),CenterOfVectors(new Vector3[] {this.transform.position,hit.transform.position}),Quaternion.LookRotation(this.transform.position,hit.transform.position));
					gameObject.transform.localScale += new Vector3(0,0,Vector3.Distance(this.transform.position,hit.transform.position));
				}
			}
			isSelected = false;
		}
	}
					      
	public Vector3 CenterOfVectors( Vector3[] vectors )
	{
	Vector3 sum = Vector3.zero;
	if( vectors == null || vectors.Length == 0 )
	{
	return sum;
	}

	foreach( Vector3 vec in vectors )
	{
	sum += vec;
	}
	return sum/vectors.Length;
	}
}
