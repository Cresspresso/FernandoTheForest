using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

	public CharacterController cc { get { return GetComponent<CharacterController>(); } }
	public float normalSpeed = 10;
	public float boostedSpeed = 20;
	public float slowSpeed = 5;
	public Vector3 eulerAngles = Vector3.zero;
	public float mouseSensitivity = 10;
	public Holdable keyBeingHeld = null;
	public Transform holdPos;
	public Transform head;
	public Transform camFollowPos;
	public Camera cam;
	public Renderer rend;
	public int playerNumber;
	public int inputControllerNumber;
	public float speedBonusTimer = 0;
	public ParticleSystem speedEffects;
	public float slowTimer = 0;
	public ParticleSystem slowEffects;
	public float wallHacksTimer = 0;
	public ParticleSystem[] wallHackEffects = new ParticleSystem[0];
	public Camera activeWhenWallHacks;
	public GameObject playerModel;
	public Animator modelAnimator;

	public float points = 0;

	private List<Collider> nearbyHoldables = new List<Collider>();

	private void Start()
	{
		activeWhenWallHacks.gameObject.SetActive(false);

		playerModel.layer = LayerMask.NameToLayer("WallHacks-" + playerNumber);
		activeWhenWallHacks.cullingMask = LayerMask.GetMask("WallHacks-" + playerNumber);

		speedEffects.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		slowEffects.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		foreach (var effects in wallHackEffects)
		{
			effects.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	public void GiveSpeedBoost(float time)
	{
		speedBonusTimer = time;
		speedEffects.Play(true);
	}

	public void GiveSlowEffect(float time)
	{
		slowTimer = time;
		slowEffects.Play(true);
	}

	public void GiveWallHacks(float time)
	{
		wallHacksTimer = time;
		foreach (var effects in wallHackEffects)
		{
			effects.Play(true);
		}
	}

	private void Update()
	{
		if (speedBonusTimer > 0)
		{
			speedBonusTimer -= Time.deltaTime;
			if (speedBonusTimer < 0)
			{
				speedBonusTimer = 0;
				speedEffects.Stop(true, ParticleSystemStopBehavior.StopEmitting);
			}
		}

		if (slowTimer > 0)
		{
			slowTimer -= Time.deltaTime;
			if (slowTimer < 0)
			{
				slowTimer = 0;
				slowEffects.Stop(true, ParticleSystemStopBehavior.StopEmitting);
			}
		}

		if (wallHacksTimer > 0)
		{
			wallHacksTimer -= Time.deltaTime;
			if (wallHacksTimer < 0)
			{
				wallHacksTimer = 0;
				foreach (var effects in wallHackEffects)
				{
					effects.Stop(true, ParticleSystemStopBehavior.StopEmitting);
				}
			}
		}

		activeWhenWallHacks.gameObject.SetActive(wallHacksTimer > 0);


		if (Input.GetKey("escape"))
        { Application.Quit(); };
		
		eulerAngles.x = Mathf.Clamp(eulerAngles.x + mouseSensitivity * -Input.GetAxis("Mouse Y-" + inputControllerNumber), -89.9f, 89.9f);
		eulerAngles.y = Mathf.Repeat(eulerAngles.y + mouseSensitivity * Input.GetAxis("Mouse X-" + inputControllerNumber), 360.0f);

		nearbyHoldables.RemoveAll(x => x == null);

		if (Input.GetButtonDown("Fire1-" + inputControllerNumber))
		{
			if (keyBeingHeld)
			{
				Drop();
			}
			else
			{
				var key = nearbyHoldables
					.Select(x => x.GetComponentInParent<Holdable>())
					.Where(x => x != null && x.playerNumberMask.Contains(this.playerNumber))
					.FirstOrDefault();
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

		foreach (var c in key.GetComponentsInChildren<Collider>())
		{
			Physics.IgnoreCollision(cc, c);
		}
	}

	public Holdable Drop()
	{
		if (keyBeingHeld)
		{
			keyBeingHeld.OnDropped();
			keyBeingHeld.rb.isKinematic = false;

			foreach (var c in keyBeingHeld.GetComponentsInChildren<Collider>())
			{
				Physics.IgnoreCollision(cc, c, false);
			}

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
		float speed = slowTimer > 0
			? slowSpeed
			: (speedBonusTimer > 0
			? boostedSpeed
			: normalSpeed);

		var v = speed * new Vector3(
			Input.GetAxis("Horizontal-" + inputControllerNumber),
			0,
			Input.GetAxis("Vertical-" + inputControllerNumber)
			);

		cc.SimpleMove(transform.rotation * (v + Physics.gravity * Time.fixedDeltaTime));

		head.transform.localEulerAngles = new Vector3(eulerAngles.x, 0, 0);
		transform.localEulerAngles = new Vector3(0, eulerAngles.y, 0);
	}

    public int GetPlayer()
    {
        return playerNumber;
    }
}
