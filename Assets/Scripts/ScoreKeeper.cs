using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;

    public void AddToScore(int points)
    {
        score += points;
        UpdateText();
    }

    public void Reset()
    {
        score = 0;
        UpdateText();
    }

    public void UpdateText()
    {

        scoreText.text = score.ToString();
    }

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
