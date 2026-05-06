using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject ScorePanel;
    private bool ScorePanelActive = false;

    public void ScorePanelToggle()
    {
        ScorePanelActive = !ScorePanelActive;
        ScorePanel.SetActive(ScorePanelActive);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Level_1");
    }
}
