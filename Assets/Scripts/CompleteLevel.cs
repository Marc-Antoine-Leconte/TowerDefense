using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

    public string menuSceneName = "MainMenu";

    public string nextLevelName = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevelName);
    }
   
    public void Menu()
    {
        Debug.Log("GoTo Menu");
        sceneFader.FadeTo(menuSceneName);
    }
}
