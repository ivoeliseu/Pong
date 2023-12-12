using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;

    private void Start()
    {
        if (isColorPlayer)
        {
            paddleReference.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            paddleReference.color = SaveController.Instance.colorEnemy;
        }
    }
    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorEnemy = paddleReference.color;
        }
    }
    
     
}

