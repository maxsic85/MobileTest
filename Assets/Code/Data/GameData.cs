using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "game", menuName = "gameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private List<LevelData> levels;
    [SerializeField] private int lives;

    public List<LevelData> Levels => levels;
    public int Lives => lives;
}