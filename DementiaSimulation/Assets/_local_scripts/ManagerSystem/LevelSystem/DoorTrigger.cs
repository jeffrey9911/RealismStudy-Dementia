using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DoorTrigger : MonoBehaviour
{
    public enum DoorNavto
    {
        Office,
        LivingRoom,
        LBathroom,
        MBathroom,
        Kitchen,
        Bedroom,
        FamilyRoom
    }

    public DoorNavto Navto;

    public Transform Character;

    void Update()
    {
        
    }
}
