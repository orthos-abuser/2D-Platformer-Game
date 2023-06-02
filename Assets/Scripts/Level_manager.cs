using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_manager : MonoBehaviour
{
    private static Level_manager instance;
    public static Level_manager Instance { get { return instance; } }

    public string level1;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("Im Here");
        if (GetLevelStatus("Level1")== levelStatus.Locked)
        {
            //Debug.Log("Here");
            SetLevelStatus("Level1", levelStatus.Unlocked);
        }
    }

    public levelStatus GetLevelStatus(string level)
    {
        levelStatus LevelStatus=(levelStatus)PlayerPrefs.GetInt(level,0);
        return LevelStatus;
    }

    public void SetLevelStatus(string level,levelStatus LevelStatus)
    {
        PlayerPrefs.SetInt(level, (int)LevelStatus);
    }
}
