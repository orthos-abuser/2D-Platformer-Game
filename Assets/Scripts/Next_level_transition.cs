using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_level_transition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_controller>() != null)
        {
            SoundManager.Instance_of_sound.Play(global::Sounds.LevelCompleted);
            Debug.Log("Here");
            int current_level =SceneManager.GetActiveScene().buildIndex;
            Level_manager.Instance.SetLevelStatus(SceneManager.GetSceneByBuildIndex(current_level).name,levelStatus.Completed);
            Level_manager.Instance.SetLevelStatus(SceneManager.GetSceneByBuildIndex(current_level+1).name,levelStatus.Unlocked);
            SceneManager.LoadScene(current_level+1);
        }
    }
}
