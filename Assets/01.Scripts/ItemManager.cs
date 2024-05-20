using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Sprite item_img;

    private void Start() {
        item_img = null; //나중에 이미지는 아이템 코드를 이름으로 하여 직접 불러올 수 있도록 할 계획
    }

    public Item ReturnItem(){
        return item;
    }
}
