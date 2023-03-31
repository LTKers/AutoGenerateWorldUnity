using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{

    private Touch initTouch=new Touch();
    public Camera cam;

    private float rotx;
    private float roty;
    private Vector3 originalrot;

    public float rotspeed=0.5f;
    public float dir=-1;
    // Start is called before the first frame update
    void Start()
    {
        originalrot=cam.transform.eulerAngles;
        rotx=originalrot.x;
        roty=originalrot.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches){
            if (touch.phase==TouchPhase.Began){
                initTouch=touch;
            }
            else if(touch.phase==TouchPhase.Moved){
                float deltax=initTouch.position.x-touch.position.x;
                float deltay=initTouch.position.y-touch.position.y;
                rotx-=deltay*Time.deltaTime*rotspeed*dir;
                roty+=deltax*Time.deltaTime*rotspeed*dir;
                rotx=Mathf.Clamp(rotx, -80f, 80f);
                roty=Mathf.Clamp(roty, -80f, 80f);
                cam.transform.eulerAngles=new Vector3(rotx, roty, 0f);
                }   
            else if(touch.phase==TouchPhase.Ended){
                initTouch=new Touch();
            }
        }
    }
}
