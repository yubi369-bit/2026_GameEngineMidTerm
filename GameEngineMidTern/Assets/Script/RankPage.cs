using UnityEngine;
using TMPro;
using System.Linq;
using System.Globalization;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;    //content 오브젝트
    [SerializeField] GameObject rowPrefab;      //Rankrow 프리팹

    StageResultList allData;

    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        foreach (Transform child in contentRoot)        //contentRoot의 자식 오브젝트 모두 제거
        {
            Destroy(child.gameObject);
        }

        var sortedData = allData.results.OrderByDescending(r => r.stage == 1).OrderByDescending(x => x.stage).ToList();     //score 내림차순, stage 오름차순으로 정렬

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);     //row 프리팹을 contentRoot의 자식으로 생성
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();     //row의 TMP_Text 컴포넌트 가져오기
            rankText.text = $"{i + 1}. {sortedData[i].PlayerName} - {sortedData[i].score}";     //rankText에 랭킹 정보 표시
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
