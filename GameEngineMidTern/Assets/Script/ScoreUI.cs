using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public GameObject scorePanel;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scorePanel.SetActive(false);
    }

    // 점수 저장
    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // 점수 불러오기
    public int LoadScore()
    {
        return PlayerPrefs.GetInt("Score", 0);
    }

    // 창 열기
    public void OpenScore()
    {
        scorePanel.SetActive(true);

        int savedScore = LoadScore();

        scoreText.text = "현재 점수 : " + savedScore;
    }

    // 창 닫기
    public void CloseScore()
    {
        scorePanel.SetActive(false);
    }
}