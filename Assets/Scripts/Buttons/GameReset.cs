using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.PointerEventData;

public class GameReset : MonoBehaviour
{
    [SerializeField]
    private Button resetGame;

    [SerializeField]
    private Button[] inputButtons;

    [SerializeField]
    private TMP_Text inputField;

    [SerializeField]
    private TMP_Text resultText;

    [SerializeField]
    private RandomNumberGenerator randomNumberGenerator;

    [SerializeField]
    private InputHandler inputHandler;

    private void OnEnable()
    {
        foreach (var button in inputButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        resetGame.onClick.AddListener(ResetGame);
    }

    private void OnDisable()
    {
        resetGame.onClick.RemoveListener(ResetGame);
    }

    private void ResetGame()
    {
        resultText.text = "( , )";
        ResultCheck.Instance.ResetTries();
        randomNumberGenerator.GetAnswer();
        inputHandler.ButtonSetup();
        inputHandler.ResetInput();
        gameObject.SetActive(false);
    }
}
