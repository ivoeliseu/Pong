using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    private void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetlastWinner();

        if (lastWinner != "")
            uiWinner.text = "Last Winner: " + lastWinner;
        else
            uiWinner.text = "";
    }
}
