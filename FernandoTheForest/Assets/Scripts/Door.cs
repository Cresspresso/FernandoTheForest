using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool isLocked = true;

	private void Start()
	{
		UpdateAnim();
	}

	public void Unlock()
	{
		isLocked = false;
		UpdateAnim();
	}

	public void UpdateAnim()
	{
		transform.localEulerAngles = isLocked ? new Vector3(0, 0, 0) : new Vector3(0, 90, 0);
	}
}
