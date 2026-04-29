using TMPro;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stage1.text = "STAGE 1 : " + HighScore.Load(1).ToString();
        stage1.text = "STAGE 2 : " + HighScore.Load(2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
