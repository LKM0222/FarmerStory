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
    string GetItemName(){
        return item_name;
    }
    int GetItemCode(){
        return item_code;
    }
    ItemType GetItemType(){
        return item_type;
    }
    int GetItemPrice(){
        return item_price;
    }
    string GetItemInfo(){
        return item_info;
    }
    #endregion

    #region Setter
    void SetItemName(string _name){
        item_name = _name;
    }
    void SetItemCode(int _code){
        item_code = _code;
    }
    void SetItemType(ItemType _type){
        item_type = _type;
    }
    void SetItemPrice(int _price){
        item_price = _price;
    }
    void SetItemInfo(string _info){
        item_info = _info;
    }
    #endregion
}
