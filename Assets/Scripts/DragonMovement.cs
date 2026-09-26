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

        spawnProjectiles();
        

        moveDragon();

    }


    void moveDragon(){
        //Move Dragon
        transform.Translate(speed * Time.deltaTime * transform.up);

        //Changes direction if at the top or bottom of the screen
        if ((transform.position.y > 4.5 && goingUp == true) || (transform.position.y < -4.5 && goingUp == false))
        {
            goingUp = !goingUp;
            speed *= -1;
        }
    }


    void spawnProjectiles() {
        spawnRat();

        spawnFireball();
    }

    void spawnRat() {
        if (ratTimer > ratWait)
        {
            Instantiate(rat, transform.position, Quaternion.identity);
            
            //reset and randomize rat timer
            ratTimer = 0;
            ratWait = Random.Range(1f, 2f);
        }
    }

    void spawnFireball() {
        if (fireballTimer > fireballWait)
        {
            GameObject spawnedFireball = Instantiate(fireball, transform.position, Quaternion.identity);

            applyFireballSpeed(spawnedFireball);

            applyFireballSize(spawnedFireball);

            //reset and randomize fireball timer
            fireballTimer = 0;
            fireballWait = Random.Range(0.1f, 2f); //was 2 to 3
        }
    }

    void applyFireballSpeed(GameObject spawnedFireball) {
        int speedEffectResults = (int)Random.Range(0f, 3f);
        if (speedEffectResults == 2) {
            spawnedFireball.GetComponent<ProjectileMovement>().speed *= 1.5f;
            spawnedFireball.GetComponent<ProjectileMovement>().points -= 200;
        }
    }

    void applyFireballSize(GameObject spawnedFireball)
    {
        int sizeEffectResults = (int)Random.Range(0, 5);
        if (sizeEffectResults == 4)
        {
            spawnedFireball.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            spawnedFireball.GetComponent<ProjectileMovement>().points -= 300;
        }

    }




}

