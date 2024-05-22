using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    #region Instance
    private static SlotManager _instance;
    public static SlotManager Instance{
        get{
            if(_instance == null) _instance = FindObjectOfType(typeof(SlotManager)) as SlotManager;
            return _instance;
        }
    }
    #endregion

    [SerializeField] Item item;
    [SerializeField] GameObject tooltip;
    [SerializeField] Text tooltipText;

    private void OnMouseOver() { //마우스가 올려졌을 때.
        string str = "";
        str += item.GetItemName() + "\n";
        str += "갯수 : 1개" + "\n";
        str += "가격 : " + item.GetItemPrice().ToString() + "\n";
        str += item.GetItemInfo();
        tooltipText.text = str;
        tooltip.GetComponent<TooltipScript>().SetXYSize(tooltip.GetComponent<RectTransform>().rect.width, tooltip.GetComponent<RectTransform>().rect.height);
        tooltip.SetActive(true);
    }

    private void OnMouseExit() { //마우스가 오브젝트에서 벗어났을 때.
        tooltip.SetActive(false);
        tooltipText.text = "";
    }

    public void SetItem(Item _item){ //아이템 가져오기 함수
        item = _item;
    }

    public void SetNullItem(){ //아이템 비우기 함수(인벤에서 아이템 삭제될 시 사용)
        item = null;
    }
    public void SetTooltipObj(GameObject _tooltip){
        tooltip = _tooltip;
    }
    public void SetTooltipTextObj(Text _tooltipText){
        tooltipText = _tooltipText;
    }
}
