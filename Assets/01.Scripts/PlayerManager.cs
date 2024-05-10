using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Moving")]
    float xpos, ypos;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }
}
