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

    //테그 확인
    private void OnTriggerStay2D(Collider2D other) {
        //아이템 습득
        if(other.tag == "Item"){ //태그 확인
            if(Input.GetKey(KeyCode.Space)){ //아이템 습득 키 확인
                GameManager.Instance.AddInventoryItem(GameManager.Instance.cropInventory, other.GetComponent<ItemManager>().ReturnItem()); //인벤토리에 아이템 추가

                GameObject go = ObjectPoolingManager.Instance.GetQueue(ObjectPoolingManager.Instance.slotQueue); //미리 만들어둔 오브젝트를 가져옴
                go.GetComponent<SlotManager>().SetItem(other.GetComponent<ItemManager>().ReturnItem()); //슬롯에 추가할 아이템 정보 받아오기.
                go.transform.GetChild(0).GetComponent<Image>().sprite = other.GetComponent<SpriteRenderer>().sprite; //이미지 변경

                go.GetComponent<SlotManager>().SetTooltipObj(GameManager.Instance.tooltip); //툴팁 오브젝트 설정
                go.GetComponent<SlotManager>().SetTooltipTextObj(GameManager.Instance.tooltipText); //툴팁 텍스트 설정

                go.transform.SetParent(GameManager.Instance.cropsParent); //부모 변경

                Destroy(other.gameObject); //인벤토리에 추가해줬으니, 오브젝트를 삭제
            }
        }

        //토양 체크
        if(other.tag == "Soil"){
            if(Input.GetKey(KeyCode.Space)){
                //아이템을 들고있고, 아이템의 갯수가 0이 아니라면
                if(GameManager.Instance.handItem.GetItemCount() > 0 && GameManager.Instance.handItem != null){
                    print(other.gameObject);
                }
            }
        }
    }
}
