using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public string _name;
    public bool IsPickable;
    public bool IsComplexed;
    public bool IsInteractable;

    private bool IsSolved;

    public GameObject required_item;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        IsSolved = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void picked()
    {
        if (IsPickable)
        {
        Debug.Log(_name + " was picked");
            gameManager.AddToInventory(gameObject);
            gameObject.SetActive(false);
        //do func to add to inventory and remove from game view
        }
    }
    public void interact()
    {
        if(IsInteractable && GameManager.Current_Item == required_item || IsSolved)
        {
            Debug.Log(required_item.name + " was used, " + _name + " preformed an interaction");
            IsSolved = true;
            if (GameManager.Current_Item == required_item) 
            {
            gameManager.RemoveFromInventory(required_item);
            }
            GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else
        {
            Debug.Log(_name +" cant touch this");
        }
        // use animator or leantween to perform some action in the game
    }

    public void complex_interact()
    {
        bool can_interact = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Object>().IsSolved == false)
            {
                can_interact = false;
                break;
            }
        }
        if (can_interact)
        {
            Debug.Log(_name + " preformed an interaction");
            GetComponent<MeshRenderer>().material.color = Color.cyan;


        }
        else
        {
            Debug.Log(_name +" cant touch this");
        }
    }

    private void OnMouseDown()
    {
        if(IsPickable && !IsInteractable && !IsComplexed)
        {
            picked();
        }
        if(!IsPickable && IsInteractable && !IsComplexed)
        {
            interact();
        }
        if (!IsPickable && !IsInteractable && IsComplexed)
        {
            complex_interact();
        }
    }
}



