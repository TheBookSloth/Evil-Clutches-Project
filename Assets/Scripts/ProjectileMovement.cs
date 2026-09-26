using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 6;
    public int points = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * -transform.right);

        if (transform.position.x < -10) {
            Destroy(gameObject);
        }
    
    }


}
