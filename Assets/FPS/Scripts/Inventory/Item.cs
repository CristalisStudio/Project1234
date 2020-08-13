using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ItemType {none, weapon, ammo, consumable }

public class Item : MonoBehaviour
{
    [System.Serializable]
    public class OnUseEvent : UnityEvent { }
    [System.Serializable]
    public class OnPickupEvent : UnityEvent { }

    public int id;
    public string title;
    public string description;
    public ItemType type;
    public Sprite icon;
    public bool IsSet = false;

    public int Timer = 0;

    public int ammo;

    [SerializeField]
    public OnUseEvent onUseEvent;
    [SerializeField]
    public OnPickupEvent onPickupEvent;

    void FixedUpdate()
    {
        if (IsSet)
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
        Timer++;
        if (Timer >= 90)
        {
            if (transform.Find("Pipe1") != null) transform.Find("Pipe1").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
            if (transform.Find("Pipe2") != null) transform.Find("Pipe2").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
            Timer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Circle")
        {
            IsSet = true;
            transform.rotation = new Quaternion();
            transform.position = collision.collider.transform.position + new Vector3(1.27f, 0, 0.35f);
        }
    }

    public Item(int id, string title, string description, ItemType itemType)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = icon;
        this.type = itemType;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = item.icon;
        this.type = item.type;
    }
}
