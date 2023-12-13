using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReset : MonoBehaviour
{
    public void ClearData()
    {
        SaveController.Instance.ClearSave();
    }
}
