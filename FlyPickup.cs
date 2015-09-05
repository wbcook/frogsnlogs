using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other){

		// If the collider other is tagged with "player"...
		if (other.CompareTag ("Player")) {

			// ...add the pickup particles...
			Instantiate(pickupPrefab, transform.position, Quaternion.identity); // (gameObject, Vector3, Quaternion rotation) identity sets 0 rotation on the particles

			// Destroy the game object this script is attached to
			Destroy (gameObject);

		}

	}

}
