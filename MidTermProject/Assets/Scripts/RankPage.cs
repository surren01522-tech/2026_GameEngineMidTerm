using System.Linq;
using UnityEngine;
using TMPro;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;
    [SerializeField] GameObject rowPrefabs;

    StageResultList allData;

    int currentStage = 1;

    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }

        Debug.Log(allData.results.Count);
        //랭크 데이터 정렬
        var sortedData = allData.results
            .Where(r => r.stage == currentStage)
            .OrderByDescending(x => x.score)
            .ToList();

        Debug.Log(sortedData.Count);
        //랭크 데이터 생성
        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefabs, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData[i].playerName} - {sortedData[i].score}";
        }
    }

    // Stage1 버튼
    public void OnClickStage1()
    {
        currentStage = 1;
        RefreshRankList();
    }

    // Stage2 버튼
    public void OnClickStage2()
    {
        currentStage = 2;
        RefreshRankList();
    }

    // Stage3 버튼
    public void OnClickStage3()
    {
        currentStage = 3;
        RefreshRankList();
    }
    public void ChangeStage(int stage)
    {
        currentStage = stage;
        RefreshRankList();
    }
}
