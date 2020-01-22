using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public string currentName;
    public GameObject inputField;

    private void Update()
    {
        inputField.GetComponent<InputField>().text = currentName;
    }
    public void AddLetter(string letter)
    {
        if(currentName.Length < inputField.GetComponent<InputField>().characterLimit)
        {
            currentName = currentName + letter;
        }
    }
    public void RemoveLetter()
    {
        if(currentName.Length > 0)
        {
            Debug.Log("Remove");
            currentName = currentName.Substring(0, currentName.Length - 1);
        }
    }
}
