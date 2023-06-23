using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum GameType
{
    Adventure = 0,
    Expert = 1,
}

[Serializable]
public class GameTypePreset
{
    public GameType gameType;
    public float startSpeed = 10f;
    public float maxSpeed = 20f;
    public float jumpHeight = 35f;
}
public class GameTypeManager : MonoBehaviour
{
    public static GameTypeManager instance;
    [SerializeField]
    public List<GameTypePreset> gameTypePresets;
    private GameType currentGameType;
    public GameType CurrentGameType { get => currentGameType; set => currentGameType = value; }
    public GameTypePreset GetCurrentPreset()
    {
        for (int i = 0; i < gameTypePresets.Count; i++)
        {
            if (gameTypePresets[i].gameType == currentGameType)
                return gameTypePresets[i];
        }
        return gameTypePresets[0];
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
