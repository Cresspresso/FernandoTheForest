using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool isLocked = true;
    Game_Loop m_Game_Loop;

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
        m_Game_Loop = GameObject.FindObjectOfType(typeof(Game_Loop)) as Game_Loop;
        m_Game_Loop.TimetoPoints();
	}
}
