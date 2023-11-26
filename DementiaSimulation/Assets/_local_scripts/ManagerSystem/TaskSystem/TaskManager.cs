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

    public GameObject GoButton;

    public GameObject FlatTask1;
    public GameObject FlatTask2;
    public GameObject FlatTask3;
    public GameObject FlatTask4;

    public OVRGrabber LGrabber;
    public OVRGrabber RGrabber;


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

        TaskStep = 0;

        TaskPanel.SetActive(true);
        TaskText.text = "The room is a mess\nYour task is to organize the objects\nPlease follow the guide\nand put the things back :)";
        GoButton.SetActive(true);



    }

    public void TaskStep1()
    {
        SwitchOff();

        TipText.text = "Tip: You can always use Left Oculus (≡) to Hide/Display the guide.";

        FlatTask1.SetActive(true);

        TaskStep = 1;
    }

    public void TaskStep2()
    {
        SwitchOff();

        TipText.text = "Tip: You can always use Left Oculus (≡) to Hide/Display the guide.";
        
        FlatTask2.SetActive(true);

        TaskStep = 2;
    }

    public void TaskStep3()
    {
        SwitchOff();

        TipText.text = "Tip: You can always use Left Oculus (≡) to Hide/Display the guide.";
        
        FlatTask3.SetActive(true);

        TaskStep = 3;
    }

    public void TaskStep4()
    {
        SwitchOff();

        TipText.text = "Tip: You can always use Left Oculus (≡) to Hide/Display the guide.";
        
        FlatTask4.SetActive(true);

        TaskStep = 4;
    }

    public void EndTask()
    {
        SwitchOff();
    }



    void SwitchOff()
    {
        TaskText.text = "";
        TipText.text = "";
        GoButton.SetActive(false);

        //GreenBook.GetComponent<OVRGrabbable>().enabled = false;
        //RedBook.GetComponent<OVRGrabbable>().enabled = false;
        //Marker.GetComponent<OVRGrabbable>().enabled = false;
        //Mouse.GetComponent<OVRGrabbable>().enabled = false;

        FlatTask1.SetActive(false);
        FlatTask2.SetActive(false);
        FlatTask3.SetActive(false);
        FlatTask4.SetActive(false);
    }
}
