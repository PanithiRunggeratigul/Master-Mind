using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomNumberGenerator : MonoBehaviour
{
    void Start()
    {
        GetAnswer();
    }

    public void GetAnswer()
    {
        List<int> numbers = Enumerable.Range(0, 10).OrderBy(x => Random.Range(0, 10)).Take(4).ToList();

        //foreach (int number in numbers)
        //{
        //    Debug.Log(number);
        //}

        SetAnswer(numbers);
    }

    private void SetAnswer(List<int> numbers)
    {
        ResultCheck.Instance.GetResult(numbers);
    }
}
