using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public CharacterController cc { get { return GetComponent<CharacterController>(); } }
	public float speed = 10;
	public Vector3 eulerAngles = Vector3.zero;
	public float mouseSensitivity = 10;

	public Transform head;

	private void Update()
	{
        if(Input.GetKey("escape"))
        { Application.Quit(); };
		eulerAngles.x = Mathf.Clamp(eulerAngles.x + mouseSensitivity * -Input.GetAxis("Mouse Y"), -89.9f, 89.9f);
		eulerAngles.y = Mathf.Repeat(eulerAngles.y + mouseSensitivity * Input.GetAxis("Mouse X"), 360.0f);
	}

	private void FixedUpdate()
	{
		cc.SimpleMove(transform.rotation * (speed * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))));

		head.transform.localEulerAngles = new Vector3(eulerAngles.x, 0, 0);
		transform.localEulerAngles = new Vector3(0, eulerAngles.y, 0);
	}
}
