using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI Stage1;
    public TextMeshProUGUI Stage2;
    void Start()
    {
        Stage1.text = "Stage 1: " + HighScore.Load(1).ToString();
        Stage2.text = "Stage 2: " + HighScore.Load(2).ToString();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
