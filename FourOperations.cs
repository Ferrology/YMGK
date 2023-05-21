using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FourOperations : MonoBehaviour
{
    public Text question;
    public Text input;
    public Text log;
    private int result;
    public enum Operation 
    {
        Addition, Subtraction, Multiplication, Division
    }
    void Start()
    {
        result = GetOperation(0,10, out string text);
        question.text = text;
    }
    public int GetOperation(int min, int max, out string opString) 
    {
        int num1 = Random.Range(min, max);
        int num2 = Random.Range(min, max);
        opString = null;
        int result = 0;
        switch ((Operation)Random.Range(0, 4))
        {
            case Operation.Addition:
                result = num1 + num2;
                opString = $"{num1} + {num2}";
                break;
            case Operation.Subtraction:
                result = num1 - num2;
                opString = $"{num1} - {num2}";
                break;
            case Operation.Division:
                if (num2 == 0) num2++;
                num1 -= num1 % num2;
                opString = $"{num1} / {num2}";
                result = num1 / num2;
                break;
            case Operation.Multiplication:
                result = num1 * num2;
                opString = $"{num1} * {num2}";
                break;
        }
        
        return result;
    }
    public bool CheckAnswer() 
    {
        if (int.TryParse(input.text, out int temp))
        {
            return temp == result;
        }
        else return false;
    }
    public void Process() 
    {
        if (CheckAnswer()) log.text = "Doðru";
        else log.text = "Yanlýþ";
        result = GetOperation(0, 10, out string text);
        question.text = text;
        input.text = null;
    }
}
