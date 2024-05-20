using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Moving")]
    float xpos, ypos;
    [SerializeField] float speed;

    [SerializeField] GameObject inventoryUI;
    // Update is called once per frame
    void Update()
    {
        //플레이어 이동
        if(Input.GetKey(KeyCode.LeftShift)){
            xpos = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed * 1.5f;
            ypos = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed * 1.5f;
        }
        else{
            xpos = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            ypos = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        }

        
        this.transform.position += new Vector3(xpos, ypos,this.transform.position.z);

        //플레이어 움직임 제한 (범위 밖으로 나가지 못하게)
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        this.transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(Input.GetKeyDown(KeyCode.I)){
            OpenInventory();
        }

    }

    //인벤토리 여는 함수 추가
    void OpenInventory(){
        if(inventoryUI.activeSelf){
            inventoryUI.SetActive(false);
        }
        else{
            inventoryUI.SetActive(true);
        }
    }


    //아이템 습득
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Item"){ //태그 확인
            if(Input.GetKey(KeyCode.Space)){ //아이템 습득 키 확인
                GameManager.Instance.AddInventoryItem(other.GetComponent<ItemManager>().ReturnItem()); //인벤토리에 아이템 추가
                
                GameObject go = ObjectPoolingManager.Instance.GetQueue(ObjectPoolingManager.Instance.slotQueue); //미리 만들어둔 오브젝트를 가져옴
                go.GetComponent<Image>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                go.transform.SetParent(GameManager.Instance.cropsParent);

                Destroy(other.gameObject); //인벤토리에 추가해줬으니, 오브젝트를 삭제
            }
        }
    }
}
