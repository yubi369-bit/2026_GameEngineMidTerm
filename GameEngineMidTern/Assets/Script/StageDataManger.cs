using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]                   //단일기록

public class StageResult
{
    public string PlayerName;       //player 이름 (PlayerPrefs에서 가져옴)

    public int stage;                   //stage 번호

public int score;                       //Score
}
[System.Serializable]
public class StageResultList
{
    public List<StageResult> results = new List<StageResult>();     //StageResult의 집합
}

public class StageResultSaver
{
    private const string FILE = "StageResult.json";
    private const string Player_Name = "PlayerName";                    //PlayerPrefs 키
    private static string filePath = Path.Combine(Application.persistentDataPath, FILE);
    public static void SaveStage(int stage, int score)
    {
        StageResultList list = LoadInternal();
        string playerName = PlayerPrefs.GetString(Player_Name, "");
        StageResult entry = new StageResult
        {
            PlayerName = playerName,
            stage = stage,
            score = score
        };
        list.results.Add(entry);                //기존 load 한 데이터의 entry 추가
        string json = JsonUtility.ToJson(list, true);       //다시 Json으로 직렬화
        File.WriteAllText(filePath, json);              //filePath에 데이터 저장
    }
    public static StageResultList LoadRank()
    {
        return LoadInternal();
    }

    private static StageResultList LoadInternal()
    {
        if (!File.Exists(filePath))                 //filePath에 파일이 없다면 
            return new StageResultList();              //새로운 리스트 생성
        string json = File.ReadAllText(filePath);               //filePath에 있는 데이터 읽어오기
        StageResultList list = JsonUtility.FromJson<StageResultList>(json);     //json에서 StageResultList 타입으로 데이터 변환
        if (list == null)                       //list가 비어있지 않다면
            return new StageResultList();           //list 가 비어있지 않다면
        else        //리스트가 비어있지 않다면
            return list;   //리스트 돌려주기



    }
    public class StageDataManger
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
