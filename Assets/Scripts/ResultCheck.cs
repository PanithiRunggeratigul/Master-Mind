using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultCheck : MonoBehaviour
{
    public static ResultCheck Instance;

    List<int> Answers = new List<int>();
    List<int> Inputs = new List<int>();

    [SerializeField]
    private TMP_Text result;

    [SerializeField]
    private GameObject endGamePanel;

    [SerializeField]
    private TMP_Text tries;

    static int triesCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void GetResult(List<int> answers)
    {
        Answers = answers;
    }

    public void CheckResult(List<int> inputs)
    {
        triesCount++;
        Inputs = inputs;

        int sameNumbers = 0;
        int sameNumbersAndIndex = 0;

        HashSet<int> ressultSet = new HashSet<int>(Answers);
        foreach (int num in Inputs)
        {
            if (ressultSet.Contains(num))
            {
                sameNumbers++;
            }
        }

        for (int i = 0; i < Answers.Count; i++)
        {
            if (Inputs[i] == Answers[i])
            {
                sameNumbersAndIndex++;
            }
        }

        result.text = $"({sameNumbers}, {sameNumbersAndIndex})";

        if (sameNumbers == 4 && sameNumbersAndIndex == 4)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
        tries.text = triesCount.ToString();
    }

    public void ResetTries()
    {
        triesCount = 0;
    }
}
