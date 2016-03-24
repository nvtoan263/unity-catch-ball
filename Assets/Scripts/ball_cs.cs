using UnityEngine;
using System.Collections.Generic;

public class ball_cs : MonoBehaviour
{

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe
                        {
                            transform.Translate(Vector3.up * 10 * Time.deltaTime);
                        }
                        else if (swipeValue < 0)//down swipe
                        {
                            transform.Translate(Vector3.down * 10 * Time.deltaTime);
                        }
                        else
                        {
                            // do nothing
                        }

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)//right swipe
                        {
                            transform.Translate(Vector3.right * 10 * Time.deltaTime);
                        }

                        else if (swipeValue < 0)//left swipe
                        {
                            transform.Translate(Vector3.left * 10 * Time.deltaTime);
                        }
                        else
                        {
                            // do nothing
                        }

                    }
                    break;
            }
        }
    }
    
}
