using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType{
    crops,
    etc
}

[System.Serializable]
public class Item 
{
    [SerializeField] string item_name;
    [SerializeField] int item_code; 
    [SerializeField] ItemType item_type;
    [SerializeField] int item_price;
    [SerializeField] string item_info;

    public Item(string _name, int _code, ItemType _type, int _price, string _info){
        item_name = _name;
        item_code = _code;
        item_type = _type;
        item_price = _price;
        item_info = _info;
    }

    #region Getter
    public string GetItemName(){
        return item_name;
    }
    public int GetItemCode(){
        return item_code;
    }
    public ItemType GetItemType(){
        return item_type;
    }
    public int GetItemPrice(){
        return item_price;
    }
    public string GetItemInfo(){
        return item_info;
    }
    #endregion

    #region Setter
    public void SetItemName(string _name){
        item_name = _name;
    }
    public void SetItemCode(int _code){
        item_code = _code;
    }
    public void SetItemType(ItemType _type){
        item_type = _type;
    }
    public void SetItemPrice(int _price){
        item_price = _price;
    }
    public void SetItemInfo(string _info){
        item_info = _info;
    }
    #endregion
}
