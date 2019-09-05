using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float points = 2000;
	public int[] keyNumberMask = new int[1] { 1 };

	public bool isLocked = true;
    Game_Loop m_Game_Loop;
	private Quaternion normalRotation;
    public AudioSource S_Door;

    private void Start()
	{
		normalRotation = transform.localRotation;
		UpdateAnim();
	}

	public void Unlock()
	{
		isLocked = false;
        S_Door.Play(0);
        S_Door.transform.SetParent(null);
        //var Game_Loop = FindObjectOfType<Game_Loop>();
        foreach (int playerNumber in keyNumberMask)
        {
            FindObjectOfType<PlayerSpawner>().playerInstances[playerNumber - 1].spawnedPlayer
                .points += points;
            //Game_Loop.TimetoPoints(playerNumber);
        }
        UpdateAnim();
	}

	public void UpdateAnim()
	{
		transform.localRotation = isLocked ? normalRotation : normalRotation * Quaternion.Euler(0, 90, 0);
	}
}
