using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticHutCam : MonoBehaviour
{
	public Transform camPos;
	public List<Player> playersInZone = new List<Player>();

	private void OnTriggerEnter(Collider other)
	{
		var player = other.GetComponentInParent<Player>();
		if (player)
		{
			var cam = player.cam.transform;
			cam.SetParent(camPos);
			cam.localPosition = Vector3.zero;
			cam.localRotation = Quaternion.identity;

			playersInZone.Add(player);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		var player = other.GetComponentInParent<Player>();
		if (player && playersInZone.Contains(player))
		{
			var cam = player.cam.transform;
			cam.SetParent(player.camFollowPos);
			cam.localPosition = Vector3.zero;
			cam.localRotation = Quaternion.identity;

			playersInZone.Remove(player);
		}
	}
}
