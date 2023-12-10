using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum DoorNavto
{
    Office,
    LivingRoom,
    MainBathroom,
    GuestBathroom,
    Kitchen,
    Bedroom,
    FamilyRoom
}

public class LevelManager : MonoBehaviour
{
    public GameObject Office;
    public GameObject LivingRoom;
    public GameObject LBathroom;
    public GameObject MBathroom;
    public GameObject Kitchen;
    public GameObject Bedroom;
    public GameObject FamilyRoom;

    private GameObject CurrentLevel;
    private GameObject CurrentDoor;

    public UserCharacter Character;
    public Transform RightHand;

    public GameObject DoorUI;
    public TMP_Text DoorText;

    private bool IsExplorationDone = false;

    bool IsOfficeDone = false;
    bool IsLivingRoomDone = false;
    bool IsLBathroomDone = false;
    bool IsMBathroomDone = false;
    bool IsKitchenDone = false;
    bool IsBedroomDone = false;
    bool IsFamilyRoomDone = false;

    private void Update()
    {
        DoorUI.transform.position = RightHand.position;
        DoorUI.transform.rotation = RightHand.rotation;

        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            SwitchRoom();
        }
    }

    [ContextMenu("SwitchRoom")]
    public void SwitchRoom()
    {
        if (DoorUI.activeSelf)
        {
            if (CurrentLevel != null)
            {
                CurrentLevel.SetActive(false);
            }

            if (CurrentDoor != null)
            {
                if (IsExplorationDone)
                {
                    int Randnum = Random.Range(1, 7);
                    switch (Randnum)
                    {
                        case 1:
                            LivingRoom.SetActive(true);
                            CurrentLevel = LivingRoom;
                            Character.Move(LivingRoom.GetComponent<LevelCentre>().Moveto.position);
                            break;
                        case 2:
                            LBathroom.SetActive(true);
                            CurrentLevel = LBathroom;
                            Character.Move(LBathroom.GetComponent<LevelCentre>().Moveto.position);
                            break;
                        case 3:
                            MBathroom.SetActive(true);
                            CurrentLevel = MBathroom;
                            Character.Move(MBathroom.GetComponent<LevelCentre>().Moveto.position);
                            break;
                        case 4:
                            Kitchen.SetActive(true);
                            CurrentLevel = Kitchen;
                            Character.Move(Kitchen.GetComponent<LevelCentre>().Moveto.position);
                            break;
                        case 5:
                            Bedroom.SetActive(true);
                            CurrentLevel = Bedroom;
                            Character.Move(Bedroom.GetComponent<LevelCentre>().Moveto.position);
                            break;
                        case 6:
                            FamilyRoom.SetActive(true);
                            CurrentLevel = FamilyRoom;
                            Character.Move(FamilyRoom.GetComponent<LevelCentre>().Moveto.position);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (CurrentDoor.GetComponent<DoorTrigger>().Navto)
                    {
                        case DoorNavto.Office:
                            Office.SetActive(true);
                            CurrentLevel = Office;
                            Character.Move(Office.GetComponent<LevelCentre>().Moveto.position);
                            IsOfficeDone = true;
                            break;
                        case DoorNavto.LivingRoom:
                            LivingRoom.SetActive(true);
                            CurrentLevel = LivingRoom;
                            Character.Move(LivingRoom.GetComponent<LevelCentre>().Moveto.position);
                            IsLivingRoomDone = true;
                            break;
                        case DoorNavto.MainBathroom:
                            LBathroom.SetActive(true);
                            CurrentLevel = LBathroom;

                            Character.Move(LBathroom.GetComponent<LevelCentre>().Moveto.position);
                            IsLBathroomDone = true;
                            break;
                        case DoorNavto.GuestBathroom:
                            MBathroom.SetActive(true);
                            CurrentLevel = MBathroom;
                            Character.Move(MBathroom.GetComponent<LevelCentre>().Moveto.position);
                            IsMBathroomDone = true;
                            break;
                        case DoorNavto.Kitchen:
                            Kitchen.SetActive(true);
                            CurrentLevel = Kitchen;
                            Character.Move(Kitchen.GetComponent<LevelCentre>().Moveto.position);
                            IsKitchenDone = true;
                            break;
                        case DoorNavto.Bedroom:
                            Bedroom.SetActive(true);
                            CurrentLevel = Bedroom;
                            Character.Move(Bedroom.GetComponent<LevelCentre>().Moveto.position);
                            IsBedroomDone = true;
                            break;
                        case DoorNavto.FamilyRoom:
                            FamilyRoom.SetActive(true);
                            CurrentLevel = FamilyRoom;
                            Character.Move(FamilyRoom.GetComponent<LevelCentre>().Moveto.position);
                            IsFamilyRoomDone = true;
                            break;
                        default:
                            break;
                    }

                    if (IsAllDone())
                    {
                        IsExplorationDone = true;
                        RuntimeManager.Instance.UI_MANAGER.TaskLayer.TaskStep1();
                    }
                }
            }

            DoorUI.SetActive(false);
        }
    }

    public void ActivateLevels()
    {
        CurrentLevel = LivingRoom;
        CurrentLevel.SetActive(true);
        IsExplorationDone = false; 
        DoorUI.SetActive(false);
    }

    public void DeactivateLevels()
    {
        LivingRoom.SetActive(false);
        Office.SetActive(false);
        LBathroom.SetActive(false);
        MBathroom.SetActive(false);
        Kitchen.SetActive(false);
        Bedroom.SetActive(false);
        FamilyRoom.SetActive(false);
    }

    public void DisplayDoorUI(GameObject DoorTrigger, bool isDisplay)
    {
        DoorUI.SetActive(isDisplay);
        CurrentDoor = DoorTrigger;

        DoorText.text = $"Click \"A\" - go to \n{CurrentDoor.GetComponent<DoorTrigger>().Navto.ToString()}";
    }

    bool IsAllDone()
    {
        return IsOfficeDone && IsLivingRoomDone && IsLBathroomDone && IsMBathroomDone && IsKitchenDone && IsBedroomDone && IsFamilyRoomDone;
    }
}
