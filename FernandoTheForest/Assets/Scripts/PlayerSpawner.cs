using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	public Player prefab;

	[System.Serializable]
	public class PlayerInstanceData
	{
		public int playerNumber;
		public int inputControllerNumber;
		public Transform spawnPoint;
		public Rect cameraRect = new Rect(0, 0, 0.5f, 0.5f);
		public Material material;
		public Animator animationModelPrefab; 

		public Player spawnedPlayer = null;
	}

	public PlayerInstanceData[] playerInstances = new PlayerInstanceData[4];

	private void OnDrawGizmos()
	{
		foreach (var data in playerInstances)
		{
			Color color = data.material.color;
			color *= 2;
			color.a = 0.7f;
			Gizmos.color = color;
			Gizmos.DrawWireSphere(data.spawnPoint.position, 1.0f);
		}
	}

	private void Awake()
	{
		if (playerInstances.Length != 4)
		{
			Debug.LogError("PlayerSpawne must have 4 players to spawn.");
		}
		
		foreach (var data in playerInstances)
		{
			if (data.spawnedPlayer == null)
			{
				var player = Instantiate(prefab, transform, true);
				player.playerNumber = data.playerNumber;
				player.inputControllerNumber = data.inputControllerNumber;
				player.name = "Player-" + data.playerNumber;
				player.transform.position = data.spawnPoint.position;
				player.transform.rotation = data.spawnPoint.rotation;
				player.cam.rect = data.cameraRect;
				player.activeWhenWallHacks.rect = data.cameraRect;
				player.rend.material = data.material;
				player.modelAnimator = Instantiate(data.animationModelPrefab, player.transform, true);
				player.modelAnimator.transform.localPosition = Vector3.up * -2f;
				data.spawnedPlayer = player;
			}
		}
	}
	
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			var last = playerInstances[playerInstances.Length - 1].spawnedPlayer.inputControllerNumber;
			for (int i = playerInstances.Length - 1; i > 0; i--)
			{
				playerInstances[i].spawnedPlayer.inputControllerNumber = playerInstances[i - 1].spawnedPlayer.inputControllerNumber;
			}
			playerInstances[0].spawnedPlayer.inputControllerNumber = last;
		}
	}
}
