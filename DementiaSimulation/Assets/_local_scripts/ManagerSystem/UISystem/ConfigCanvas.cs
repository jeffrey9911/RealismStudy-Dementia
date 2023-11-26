using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text DebugText;

    public void UISystemMessage(string message)
    {
        DebugText.text = message;
    }

    [ContextMenu("Start Flat")]
    public void StartFlat()
    {
        RuntimeManager.Instance.UI_MANAGER.StartTutorialCanvas();
    }
}
