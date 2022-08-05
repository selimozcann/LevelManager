using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level[] _level;
    [SerializeField] private Level testLevel;
    [SerializeField] private int levelIndex;

    private const string levelStr = "Level";
    
    private void Awake()
    {
        InitLevel();
    }
    private void InitLevel()
    {
        levelIndex = GetLevel();
        if(levelIndex >= 3)
        {
            levelIndex = 0;
        }

       
        Level level = testLevel != null ? LevelSpawn(testLevel) : LevelSpawn(_level[levelIndex]);
    }
    private Level LevelSpawn(Level level) => Instantiate(level,level.transform.position, Quaternion.identity);
    private int GetLevel() => PlayerPrefs.GetInt(levelStr);
    private void SetLevel() => PlayerPrefs.SetInt(levelStr,levelIndex);
}
