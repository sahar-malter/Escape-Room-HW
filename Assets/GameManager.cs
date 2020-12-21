using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> inventory;
    public static GameObject Current_Item;
    public List<Button> button_inventory;
    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void select_current_item(int index)
    {
        if (inventory[index] != null)
        {
            Current_Item = inventory[index];
            Debug.Log(inventory[index].name + " is now the current item");
            _index = index; 
        }
        else 
        { 
            Current_Item = null;
        }
    }

    public void AddToInventory(GameObject picked_item)
    {
        inventory.Add(picked_item);
        Debug.Log(picked_item + " was added to the inventory");
        button_inventory[inventory.Count-1].GetComponent<Image>().color = picked_item.GetComponent<MeshRenderer>().material.color;
    }
    public void RemoveFromInventory(GameObject used_item)
    {

        inventory.Remove(used_item);
        Debug.Log(used_item + " was removed from the inventory");
        for (int i = _index; i < button_inventory.Count-1; i++)
        {
            button_inventory[i].GetComponent<Image>().color = button_inventory[i + 1].GetComponent<Image>().color;
        }
        button_inventory[button_inventory.Count-1].GetComponent<Image>().color = Color.white;
    }
}
