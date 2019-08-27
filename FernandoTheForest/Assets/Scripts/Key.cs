using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
	{
		var door = collision.collider.GetComponentInParent<Door>();
		if (door != null)
		{
			door.Unlock();
			Destroy(gameObject);
		}
	}
}
