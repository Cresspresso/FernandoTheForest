using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public CharacterController cc { get { return GetComponent<CharacterController>(); } }
	public float speed = 10;
	public Vector3 eulerAngles = Vector3.zero;

	public Transform head;

	private void Update()
	{
		
	}

	private void FixedUpdate()
	{
		cc.SimpleMove(speed * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
		head.transform.localEulerAngles = new Vector3(eulerAngles.x, 0, 0);
		transform.localEulerAngles = new Vector3(0, eulerAngles.y, 0);
	}
}
