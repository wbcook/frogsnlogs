using UnityEngine;
using System.Collections;

public class FlyMovement : MonoBehaviour {

	[SerializeField]
	private Transform center;

	private float flySpeed;

	// Use this for initialization
	void Start () {

		// pick a value between 300 and 700 for the fly move speed
		flySpeed = Random.Range (300f, 700f);
	
	}
	
	// Update is called once per frame
	void Update () {

		// RotateAround does the math to make the fly fly around its center geometry
		transform.RotateAround (center.position, Vector3.up, flySpeed * Time.deltaTime);
	
	}
}
