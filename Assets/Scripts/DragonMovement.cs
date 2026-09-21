using System;
using Unity.VisualScripting;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float speed = 5;
    public bool goingUp = true;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.up);

        if ((transform.position.y > 4.5 && goingUp == true) || (transform.position.y < -4.5 && goingUp == false)) {
            goingUp = !goingUp;
            speed *= -1;
        }
    }
}
