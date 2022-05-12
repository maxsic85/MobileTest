using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "game", menuName = "gameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private List<LevelData> levels;
    [SerializeField] private int lives;
    [SerializeField] private int currentLevel;


    public List<LevelData> Levels => levels;
    public int Lives => lives;

    public int CurrentLevelIndex { get => currentLevel; set => currentLevel = value; }
    public LevelData CurrentLevel =>Levels[CurrentLevelIndex];  
}