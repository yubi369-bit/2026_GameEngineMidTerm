using UnityEngine;

public class Score1 : MonoBehaviour
{
    public GameObject helpPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helpPanel.SetActive(false);
    }

    public void OpenHelp()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
