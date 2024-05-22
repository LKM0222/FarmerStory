using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Instance
    private static GameManager _instance;
    public static GameManager Instance{
        get{
            if(_instance == null) _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            return _instance;
        }
    }
    #endregion

    #region Parents
    public Transform cropsParent;
    #endregion

    #region Tooltip
    public GameObject tooltip;
    public Text tooltipText;
    #endregion

    [SerializeField] List<Item> inventory = new List<Item>();

    public void AddInventoryItem(Item item){
        inventory.Add(item);
    }
    public void DeleteInventoryItem(Item item){
        inventory.Remove(item);
    }

}
