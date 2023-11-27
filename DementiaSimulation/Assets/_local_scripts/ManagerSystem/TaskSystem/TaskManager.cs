using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public Transform CenterEye;
    public Transform TaskUIFollow;

    public Vector3 OrigPos = new Vector3(-4f, 2.7f, 2f);

    public GameObject TaskPanel;
    public TMP_Text TaskText;
    public TMP_Text TipText;

    private int TaskStep = -1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIFollow();
    }

    void UIFollow()
    {
        Quaternion lookatRot = Quaternion.LookRotation(CenterEye.transform.position - this.transform.position, Vector3.up);

        this.transform.localRotation = Quaternion.Lerp(this.transform.rotation, lookatRot, Time.deltaTime * 5.0f);

        if(TaskStep > 0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, TaskUIFollow.position, Time.deltaTime * 5.0f);
            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                TaskPanel.SetActive(!TaskPanel.activeSelf);
            }
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, OrigPos, Time.deltaTime * 5.0f);
        }
    }

    public void StartTaskLayer()
    {
        SwitchOff();

        TaskStep = 1;

        TaskPanel.SetActive(true);

        TaskText.text = "Now is the time to explore all the rooms";

        TipText.text = "Tip: You can always use Left Oculus (≡) to Hide/Display the guide.";



    }

    public void TaskStep1()
    {
        SwitchOff();

        TaskText.text = "Please go to your office and find your green book!";

        TipText.text = "Tip: You can always use Left Oculus (≡) to Hide/Display the guide.";
    }

    public void EndTask()
    {
        SwitchOff();
    }



    void SwitchOff()
    {
        TaskText.text = "";
        TipText.text = "";
    }
}
