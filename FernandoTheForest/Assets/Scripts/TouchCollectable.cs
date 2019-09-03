using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollectable : MonoBehaviour {
	
	protected virtual void OnTouched(Player player)
	{
		Destroy(gameObject);
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		var player = other.GetComponentInParent<Player>();
		if (player)
		{
			OnTouched(player);
		}
	}
}
