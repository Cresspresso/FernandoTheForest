using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentScores : MonoBehaviour {

    [System.Serializable]
    public struct PlayerData
    {
        public float points;
        public bool wasSafe;
    }

	public PlayerData[] stats = new PlayerData[4];

	static PersistentScores instance_;
	public static PersistentScores instance
	{
		get
		{
			if (!instance_)
			{
				instance_ = FindObjectOfType<PersistentScores>();
			}
			return instance_;
		}
		private set {
			if (instance_)
			{
				Destroy(instance_);
			}
			instance_ = value;
			DontDestroyOnLoad(value.gameObject);
		}
	}

	private void Awake()
	{
		if (!instance_)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
