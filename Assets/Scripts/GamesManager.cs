using UnityEngine;

public class GamesManager : MonoBehaviour {

    public static bool GameOver = false;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameOver = false;
    }

	void Update () {
        if (GameOver)
            return;

        if (PlayerStats.Lives <= 0)
            EndGame();
	}

    private void EndGame()
    {
        gameOverUI.SetActive(true);
        GameOver = true;
    }

    public void WinLevel()
    {
        GameOver = true;
        completeLevelUI.SetActive(true);   
    }
}
