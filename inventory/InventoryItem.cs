using UnityEngine;
using UnityEngine.UI;



// no need for weapon, the game object script will inherit from this
public class InventoryItem : ScriptableObject
{
    public enum ItemType
    {
        WEAPON,
        FOOD,
        MISC
    }

    public int item_id;
    public string item_name;
    public string item_desc;
    public Image item_image;
    public ItemType item_type = ItemType.MISC;
    public GameObject item_obj;
}
