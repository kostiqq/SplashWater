using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Grid grid;
    private Object pref;
    private PrefabStorage prefabStorage;
    private LevelBuilder levelBuilder;
    private MeshManager meshManager;
    internal bool isPlaying;

    void Start()
    {
        prefabStorage = new PrefabStorage();
        levelBuilder = new LevelBuilder(this);
        meshManager = new MeshManager(levelBuilder, prefabStorage, grid);
        GameObject.Find("WaterDrop").GetComponent<PlayerController>().Builder = levelBuilder;
        meshManager.CreateRoad();
        isPlaying = true;

    }

    void Update()
    {
        if (isPlaying)
        {
            meshManager.Update();
        }
    }

    public void Restart()
    {
        levelBuilder.Retry();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
