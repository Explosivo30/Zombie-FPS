using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class exitDoor : MonoBehaviour
{
    public GameObject PuertaExit;
    public GameObject PressButtonUI;

    private bool dentrotrigger = false;
    private bool NPCdentrotrigger = false;
    private bool DoorIsOpen = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (dentrotrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && !DoorIsOpen)
            {
                Invoke("OpenDoor", 0f);
            }
        }
        if (NPCdentrotrigger == true && !DoorIsOpen)
        {
            Invoke("OpenDoor", 0f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = true;
            PressButtonUI.SetActive(true);
        }
        if (other.gameObject.CompareTag("NPC"))
        {
            NPCdentrotrigger = true;
            Debug.Log("Dentro del Trigger");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentrotrigger = false;
            PressButtonUI.SetActive(false);
        }
        if (other.gameObject.CompareTag("NPC"))
        {
            NPCdentrotrigger = false;
        }
    }

    private void OpenDoor()
    {
        PuertaExit.transform.Rotate(0f, 90f, 0.0f, Space.Self);
        Invoke("CloseDoor", 3f);
        DoorIsOpen = true;
    }
    private void CloseDoor()
    {
        PuertaExit.transform.Rotate(0f, -90f, 0.0f, Space.Self);
        DoorIsOpen = false;
    }
}
