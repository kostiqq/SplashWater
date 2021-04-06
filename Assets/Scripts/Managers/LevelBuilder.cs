using UnityEngine;

public class LevelBuilder
{
    private GameObject winWindow;
    private GameObject gameOverWindow;
    private GameManager gameManager;
    public Level level { get; private set; }

    public LevelBuilder(GameManager gameManager)
    {
        this.gameManager = gameManager;
        winWindow = GameObject.Find("Congrats!");
        gameOverWindow = GameObject.Find("GameOver");
        level = GameObject.Find("GameManager").GetComponent<Level>();
    }

    public void Retry()
    {
        level.StartGame();
    }

    public void Win()
    {
        gameManager.isPlaying = false;
        level.Stage++;
        winWindow.GetComponent<Animator>().SetTrigger("Show");
    }
    public void GameOver()
    {
        gameManager.isPlaying = false;
        gameOverWindow.GetComponent<Animator>().SetTrigger("Show");
    }

}
