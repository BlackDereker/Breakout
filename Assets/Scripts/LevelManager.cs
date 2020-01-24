using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    public Level CurrentLevel { get; set; }

    [SerializeField]
    private Level[] levels;

    private int currentLevelIndex;


    void Awake()
    {

        Instance = this;

    }

    public void NextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    public void PreviousLevel()
    {
        LoadLevel(currentLevelIndex - 1);
    }

    public void LoadLevel(int levelIndex)
    {

        if (CurrentLevel) {
            Destroy(CurrentLevel.gameObject);
        }

        CurrentLevel = Instantiate(levels[levelIndex], Vector2.zero, Quaternion.identity, transform);

        currentLevelIndex = levelIndex;

        GameManager.Instance.player.ResetPlayer();


    }


}
