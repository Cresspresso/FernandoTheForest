using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public CharacterController cc { get { return GetComponent<CharacterController>(); } }
	public float speed = 10;

	private void FixedUpdate()
	{
		cc.SimpleMove(speed * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
	}
}
