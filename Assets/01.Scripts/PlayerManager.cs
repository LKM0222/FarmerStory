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
        if(Input.GetKey(KeyCode.Space)){
            xpos = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed * 1.5f;
            ypos = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed * 1.5f;
        }
        else{
            xpos = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            ypos = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        }

        
        this.transform.position += new Vector3(xpos, ypos,this.transform.position.z);
    }
}
