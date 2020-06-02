using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{
    public static inputController Instance { get; set; }
    bool tap, swipeLeft, swipeRigt, swipeUp, swipeDown;
    Vector2 swipeDelta, startTouch;
    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft{ get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRigt; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    private const float DEADZONE = 10F;

    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {

        tap = swipeDown = swipeLeft = swipeRigt = swipeUp = false;

        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase==TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }

        //calculate distance

        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            //lef check with mobile
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }

        }
        //check if we are beyond the deadzone

        if (swipeDelta.magnitude > DEADZONE)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRigt = true;
                }
            }
            else
            {
                //UP or Down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }


}
