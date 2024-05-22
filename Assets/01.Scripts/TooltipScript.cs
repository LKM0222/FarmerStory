using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipScript : MonoBehaviour
{
    [SerializeField] float x,y;
    [SerializeField] Vector3 mousePos;

    private void Start() {
        x = this.GetComponent<RectTransform>().rect.width / 2; //각각의 세로 반크기, 가로 반넓이를 구함.
        y = this.GetComponent<RectTransform>().rect.height / 2;
        print("rect is" + x + ", " +y);
    }

    // Update is called once per frame
    void Update()//여기서 Update를 쓰는 이유는 Active상태일때만 작동하기 때문. 마우스의 위치를 따라 다니게 하고싶음.
    {
        // mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + (x/2), Input.mousePosition.y + (-y/2), -Input.mousePosition.z));
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    public void SetXYSize(float _x, float _y){
        this.x = _x;
        this.y = _y;
    }
}
