
using UnityEngine;
[CreateAssetMenu(fileName = "level", menuName = "levelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int countTail;
    [SerializeField] private float levelStepTime;

    public int Level  => level;
    public int CountTail  => countTail;
    public float LevelStepTime  => levelStepTime; 
}
