using UnityEngine;
using System.Collections;

public class KeepLink : MonoBehaviour {

	public Transform TransformA;
	public Transform TransformB;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = CenterOfVectors(new Vector3[]        {
			TransformA.position,
			TransformB.position
		});

		this.transform.rotation = Quaternion.LookRotation(TransformB.position-TransformA.position);

		gameObject.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, Vector3.Distance(TransformA.position, TransformB.position));
	}

	public Vector3 CenterOfVectors(Vector3[] vectors)
	{
		Vector3 sum = Vector3.zero;
		if (vectors == null || vectors.Length == 0)
		{
			return sum;
		}
		
		foreach (Vector3 vec in vectors)
		{
			sum += vec;
		}
		return sum / vectors.Length;
	}
}
