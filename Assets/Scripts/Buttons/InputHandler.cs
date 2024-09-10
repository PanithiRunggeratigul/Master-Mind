using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text inputText;

    [Header("Number Button")]
    [SerializeField]
    private Button[] numberButtons;

    [Header("Reset Button")]
    [SerializeField]
    private Button resetButton;

    [Header("Submit Button")]
    [SerializeField]
    private Button submitButton;

    private List<int> numbers = new List<int>();

    private void Start()
    {
        ButtonSetup();
    }

    public void ButtonSetup()
    {
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int index = i;
            numberButtons[i].onClick.AddListener(() => TaskOnClick(index));
        }

        resetButton.onClick.AddListener(ResetInput);
        submitButton.onClick.AddListener(SubmitInput);
    }

    private void TaskOnClick(int number)
    {
        if (numbers.Count > 4)
        {
            return;
        }

        numbers.Add(number);
        UpdateDisplay();
    }

    public void ResetInput()
    {
        numbers.Clear();
        UpdateDisplay();
    }

    private void SubmitInput()
    {
        if (numbers.Count != 4)
        {
            return;
        }

        ResultCheck.Instance.CheckResult(numbers);
    }

    private void UpdateDisplay()
    {
        string display = "";
        for (int i = 0; i < 4; i++)
        {
            if (i < numbers.Count)
            {
                display += numbers[i] + " ";
            }
            else
            {
                display += "_ ";
            }
        }
        inputText.text = display.TrimEnd();
    }
}
