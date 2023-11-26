using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public ConfigCanvas ConfigLayer;

    [SerializeField] public TutorialManager TutorialLayer;

    [SerializeField] public TaskManager TaskLayer;

    [SerializeField] public GameObject UserLevel;
    [SerializeField] public GameObject TutorialLevel;


    // Start with Config Canvas
    private void Start()
    {
        if (OVRManager.isHmdPresent)
        {
            RuntimeManager.Instance.UI_MANAGER.ConfigLayer.UISystemMessage($"Current Device: {OVRPlugin.GetSystemHeadsetType().ToString()}");
        }

        RestartLayers();
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            RestartLayers();
        }
    }

    public void RestartLayers()
    {
        ConfigLayer.gameObject.SetActive(true);
        TutorialLayer.gameObject.SetActive(false);
        TaskLayer.gameObject.SetActive(false);

        ActiveTutorialLevel();
    }

    // Tutorial Canvas
    [ContextMenu("StartTutorialCanvas")]
    public void StartTutorialCanvas()
    {
        ConfigLayer.gameObject.SetActive(false);
        TutorialLayer.gameObject.SetActive(true);
        TaskLayer.gameObject.SetActive(false);

        TutorialLayer.StartTutorial();
    }

    public void StartTaskCanvas()
    {
        ConfigLayer.gameObject.SetActive(false);
        TutorialLayer.gameObject.SetActive(false);
        TaskLayer.gameObject.SetActive(true);

        TaskLayer.StartTaskLayer();
    }

    public void ActiveTutorialLevel()
    {
        UserLevel.SetActive(false);
        TutorialLevel.SetActive(true);
    }

    public void ActiveUserLevel()
    {
        UserLevel.SetActive(true);
        TutorialLevel.SetActive(false);
    }

    [ContextMenu("StartTask")]
    public void StartTask()
    {
        ActiveUserLevel();

        StartTaskCanvas();
    }

}
