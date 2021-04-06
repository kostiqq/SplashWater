using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private LevelMap map;
    private int loadedStage;
    public int Stage { get; set; } = 1;
    public LevelMap Map
    {
        get
        {
            if (loadedStage != Stage)
            {
                LoadLevel();
            }
            return map;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        loadedStage = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void LoadLevel()
    {
            string json = Resources.Load<TextAsset>($"Levels/level{Stage}").text;
            map = JsonUtility.FromJson<LevelMap>(json);
    }
}
