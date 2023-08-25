using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public float ItemIndex;
    public int count = 1;
    public TextMeshProUGUI countText;
    public InputAction mousePosition;
    public Vector3 currentMousePosition;
    public Transform parentAfterDrag;
    public Image image;
    public GameObject selfPrefab;
    public int Position;

    private void Awake()
    {
        image.sprite = item.icon;
        ItemIndex = item.ItemIndex;
        mousePosition.Enable();
        mousePosition.performed += context => { currentMousePosition = context.ReadValue<Vector2>(); };
    }

    private void Start()
    {
        RefreshCount();
    }
  
    public void RefreshCount() //Refreshes the item stack number
    {
        if (count > 1)
        {
            countText.text = count.ToString();
        }
        else
        {
            countText.text = null;
        }
    }

    public void failedDrag() //Triggers when an previously stacked item fails to be dragged to a valid location, in order to keep each slot with a single item.
    {
        if (parentAfterDrag.childCount > 0)
        {
            parentAfterDrag.GetComponentInChildren<DraggableItem>().addCount();
            Destroy(gameObject);
        }
    }

    public void addCount() //Adds an item to the stack, triggers when a certain item is placed on top of the same kind of item, stacking them.
    {
        count++;
        RefreshCount();
    }

    public void OnBeginDrag(PointerEventData eventData) //Triggers when the item is clicked, either drags the item itself if its not stacked, or a copy of it if stacked
    {
        parentAfterDrag = transform.parent;
        if (count == 1)
        {
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
        else if (count > 1)
        {
            eventData.pointerDrag = Instantiate(selfPrefab, transform.parent);
            eventData.pointerDrag.transform.SetParent(transform.root);
            eventData.pointerDrag.transform.SetAsLastSibling();
            eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;
            count--;
            eventData.pointerDrag.GetComponent<DraggableItem>().count = 1;
            eventData.pointerDrag.GetComponent<DraggableItem>().RefreshCount();
            RefreshCount();
        }
    }

    public void OnDrag(PointerEventData eventData) //Stays active during the drag, keeps the item on the mouse.
    {
        transform.position = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) //Places the item on the correct place and updates the array.
    {
        RefreshCount();
        transform.SetParent(parentAfterDrag);
        transform.position = parentAfterDrag.position;
        image.raycastTarget = true;
        MinigameManager.instance.UpdateArray();
    }
}
