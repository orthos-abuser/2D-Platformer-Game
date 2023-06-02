using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Level_select_button : MonoBehaviour
{
    private Button button;
    public int level;

    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        levelStatus LevelS = Level_manager.Instance.GetLevelStatus(LevelName);
        Debug.Log(LevelS);
        switch (LevelS)
        {
            case levelStatus.Locked:
                Debug.Log("Cannot play the level until you unlock it");
            break;

            case levelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
            break;

            case levelStatus.Completed:
                SceneManager.LoadScene(LevelName);
            break;
        }
    }
}
