using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotsParent;
    private List<GameObject> slots = new List<GameObject>();
    public GameObject inventoryPanel;
    private bool slotsCreated = false;


    private bool isOpen = false;

    void Start()
    {
        if (!slotsCreated)
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject slot = Instantiate(slotPrefab, slotsParent);
                slots.Add(slot);
            }
            slotsCreated = true;
        }

        inventoryPanel.SetActive(isOpen);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);
            Debug.Log("Inventário alternado: " + isOpen);
        }
        for (int i = 0; i < slots.Count; i++)
        {
            Image icon = slots[i].transform.GetChild(0).GetComponent<Image>();

            if (i < inventory.items.Count)
            {
                icon.sprite = inventory.items[i].icon;
                icon.enabled = true;
            }
            else
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }
    }
}
