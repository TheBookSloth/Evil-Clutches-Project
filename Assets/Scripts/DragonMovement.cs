using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float speed = 5;
    public bool goingUp = true;

    //rat and fireball timers
    private float ratWait = 1, fireballWait = 2;
    private float ratTimer = 0, fireballTimer = 0;

    public GameObject rat, fireball;

    // Update is called once per frame
    void Update()
    {
        //Increase timers
        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;

        if (ratTimer > ratWait) {
            Instantiate(rat, transform.position, Quaternion.identity);
            ratTimer = 0;
            ratWait = Random.Range(1f, 2f);
        }

        if (fireballTimer > fireballWait)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballWait = Random.Range(2f, 3f);
        }

        //Move Dragon
        transform.Translate(speed * Time.deltaTime * transform.up);

        //Changes direction if at the top or bottom of the screen
        if ((transform.position.y > 4.5 && goingUp == true) || (transform.position.y < -4.5 && goingUp == false)) {
            goingUp = !goingUp;
            speed *= -1;
        }



    }
}
