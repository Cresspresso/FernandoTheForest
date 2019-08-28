using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

	public CharacterController cc { get { return GetComponent<CharacterController>(); } }
	public float speed = 10;
	public Vector3 eulerAngles = Vector3.zero;
	public float mouseSensitivity = 10;
	public Holdable keyBeingHeld = null;
	public Transform holdPos;
	public Transform head;
	[Range(1, 2)]
	public int playerNumber = 1;

	public float points = 0;

	private List<Collider> nearbyHoldables = new List<Collider>();

	private void Update()
	{
		if(Input.GetKey("escape"))
        { Application.Quit(); };
		
		eulerAngles.x = Mathf.Clamp(eulerAngles.x + mouseSensitivity * -Input.GetAxis("Mouse Y-" + playerNumber), -89.9f, 89.9f);
		eulerAngles.y = Mathf.Repeat(eulerAngles.y + mouseSensitivity * Input.GetAxis("Mouse X-" + playerNumber), 360.0f);

		nearbyHoldables.RemoveAll(x => x == null || x.GetComponent<Holdable>() == null);

		if (Input.GetButtonDown("Fire1-" + playerNumber))
		{
			if (keyBeingHeld)
			{
				Drop();
			}
			else
			{
				var key = nearbyHoldables.Select(x => x.GetComponent<Holdable>()).FirstOrDefault();
				if (key)
				{
					Hold(key);
				}
			}
		}
	}

	public void Hold(Holdable key)
	{
		this.keyBeingHeld = key;
		key.rb.isKinematic = true;
		key.OnHeldBy(this);
	}

	public Holdable Drop()
	{
		if (keyBeingHeld)
		{
			keyBeingHeld.OnDropped();
			keyBeingHeld.rb.isKinematic = false;
			var key = keyBeingHeld;
			keyBeingHeld = null;
			return key;
		}
		return null;
	}

	private void OnDestroy()
	{
		Drop();
	}

	private void OnTriggerEnter(Collider other)
	{
		var key = other.GetComponentInParent<Holdable>();
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
	}
}
