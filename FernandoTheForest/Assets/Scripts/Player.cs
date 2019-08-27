using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

	public CharacterController cc { get { return GetComponent<CharacterController>(); } }
	public float speed = 10;
	public Vector3 eulerAngles = Vector3.zero;
	public float mouseSensitivity = 10;
	public Rigidbody key = null;
	public Transform holdPos;
	public Transform head;
	[Range(1, 2)]
	public int playerNumber = 1;

	private List<Collider> nearbyHoldables = new List<Collider>();

	private void Update()
	{
		if(Input.GetKey("escape"))
        { Application.Quit(); };
		
		eulerAngles.x = Mathf.Clamp(eulerAngles.x + mouseSensitivity * -Input.GetAxis("Mouse Y-" + playerNumber), -89.9f, 89.9f);
		eulerAngles.y = Mathf.Repeat(eulerAngles.y + mouseSensitivity * Input.GetAxis("Mouse X-" + playerNumber), 360.0f);

		if (Input.GetButtonDown("Fire1-" + playerNumber))
		{
			if (key)
			{
				Drop();
			}
			else
			{
				var holdable = nearbyHoldables.FirstOrDefault(x => x.GetComponent<Key>() != null);
				if (holdable)
				{
					Hold(holdable.GetComponent<Rigidbody>());
				}
			}
		}
	}

	public void Hold(Rigidbody rb)
	{
		key = rb;
		key.isKinematic = true;
	}

	public Rigidbody Drop()
	{
		key.isKinematic = false;
		var old = key;
		key = null;
		return old;
	}

	private void OnTriggerEnter(Collider other)
	{
		var key = other.GetComponentInParent<Key>();
		if (key != null)
		{
			nearbyHoldables.Add(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		nearbyHoldables.Remove(other);
	}

	private void FixedUpdate()
	{
		cc.SimpleMove(transform.rotation * (speed * new Vector3(Input.GetAxis("Horizontal-" + playerNumber), 0, Input.GetAxis("Vertical-"+ playerNumber))));

		head.transform.localEulerAngles = new Vector3(eulerAngles.x, 0, 0);
		transform.localEulerAngles = new Vector3(0, eulerAngles.y, 0);

		if (key)
		{
			key.MovePosition(holdPos.position);
			key.MoveRotation(holdPos.rotation);
		}
	}
}
