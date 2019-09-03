﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public int[] keyNumberMask = new int[1] { 1 };

	public bool isLocked = true;
    Game_Loop m_Game_Loop;
	private Quaternion normalRotation;

	private void Start()
	{
		normalRotation = transform.localRotation;
		UpdateAnim();
	}

	public void Unlock()
	{
		isLocked = false;
        var Game_Loop = FindObjectOfType<Game_Loop>();
        foreach (int playerNumber in keyNumberMask)
        {
            Game_Loop.TimetoPoints(playerNumber);
        }
        UpdateAnim();
	}

	public void UpdateAnim()
	{
		transform.localRotation = isLocked ? normalRotation : normalRotation * Quaternion.Euler(0, 90, 0);
	}
}
