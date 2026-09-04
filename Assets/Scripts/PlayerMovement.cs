using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;

    // Update is called once per frame
    void Update()
    {
        //traveling up
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(speed * Time.deltaTime * transform.up);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            transform.Translate(speed * Time.deltaTime * -transform.up);
        }
    }
}
