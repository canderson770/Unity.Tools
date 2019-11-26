using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidateInputField : MonoBehaviour
{
    private TMP_InputField input;

    public bool isLetter = false;
    public bool isNumber = false;

    public List<char> possibleChars = new List<char>();

    private void Awake()
    {
        input = GetComponent<TMP_InputField>();
    }

    private void OnEnable()
    {
        if (input != null)
        {
            input.onValidateInput += Validate;
        }
    }

    private void OnDisable()
    {
        if (input != null)
        {
            input.onValidateInput -= Validate;
        }
    }

    private char Validate(string text, int charIndex, char addedChar)
    {
        //  if letter
        if (char.IsLetter(addedChar) && isLetter)
            return addedChar;

        //  if number
        if (char.IsDigit(addedChar) && isNumber)
            return addedChar;

        //  if in list of possible chars
        foreach (var c in possibleChars)
        {
            if (addedChar == c)
                return addedChar;
        }

        //  else don't allow
        return '\0';
    }
}
