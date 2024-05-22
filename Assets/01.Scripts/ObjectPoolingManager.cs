using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager Instance;

    #region  slot
    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject slotParent;
    public Queue<GameObject> slotQueue = new Queue<GameObject>();
    #endregion
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }
    private void Start() {
        //slot 오브젝트 2000개 미리 생성
        for(int i = 0; i< 2000;i++){
            GameObject slot = Instantiate(slotPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity, slotParent.transform);
            slot.SetActive(false);
            slotQueue.Enqueue(slot);
        }
    }

    public void InsertQueue(GameObject go, Queue queue){ //오브젝트를 숨길때
        queue.Enqueue(go);
        go.SetActive(false);
    }

    public GameObject GetQueue(Queue<GameObject> queue){ //오브젝트를 꺼낼때
        GameObject go = queue.Dequeue();
        go.SetActive(true);
        return go;
    }
}
