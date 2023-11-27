using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DoorTrigger : MonoBehaviour
{

    public DoorNavto Navto;

    public Transform Character;

    private bool IsInDistance = false;

    void Update()
    {
        Debug.Log(Vector3.Distance(Character.position, this.transform.position));
        if(IsCharacterInDistance() != IsInDistance)
        {
            IsInDistance = IsCharacterInDistance();
            SendTriggerMsg(IsInDistance);
        }
    }

    bool IsCharacterInDistance()
    {
        return Vector3.Distance(Character.position, this.transform.position) < 2f;
    }

    void SendTriggerMsg(bool isDisplay)
    {
        RuntimeManager.Instance.LEVEL_MANAGER.DisplayDoorUI(this.gameObject, isDisplay);
    }
}
