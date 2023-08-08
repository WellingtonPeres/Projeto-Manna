using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{

    DraggableItem draggedItem;
    public bool stackable;
    public float itemIndex;  //0 Empty //1 Wire //2 Resistor //3 Battery //4 Lamp

    private void Start()
    {
        if(transform.childCount == 1)
        {
           draggedItem = transform.GetChild(0).GetComponent<DraggableItem>();
           SetPosition();
           itemIndex = draggedItem.ItemIndex;
        }
    }
    public void OnDrop(PointerEventData eventData) // Triggers when an item is dropped on top of the slot,Adds the current dragged item to itself as a child if empty,
        //If it currently has a child, stacks the item if both are equal or cancels the drop action if theyre different
    {
        if (transform.childCount == 0)
        {
            draggedItem = eventData.pointerDrag.GetComponent<DraggableItem>();
            draggedItem.parentAfterDrag = transform;
            SetPosition();
            itemIndex = draggedItem.ItemIndex;
        }
        else if (transform.childCount == 1 && stackable)
        {
            if (draggedItem.item == eventData.pointerDrag.GetComponent<DraggableItem>().item)
            {
                draggedItem.count += eventData.pointerDrag.GetComponent<DraggableItem>().count;
                draggedItem.RefreshCount();
                Destroy(eventData.pointerDrag.gameObject);
                eventData.pointerDrag = null;
            }
            else
            {
                eventData.pointerDrag.GetComponent<DraggableItem>().failedDrag();
            }
        }
        
    }
    public void SetPosition() //Gets its position on the array and assigns it to its current item
    {
        int position = MinigameManager.instance.GetPosition(gameObject);
        draggedItem.Position = position;
    }

}
