using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    private int score = 0;

    public TextMeshProUGUI scoreBox;

    // Update is called once per frame
    void Update()
    {
        //traveling up or down
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(speed * Time.deltaTime * transform.up);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(speed * Time.deltaTime * -transform.up);
        }

        //traveling right or left
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime * transform.right);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * Time.deltaTime * -transform.right);
        }


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 4.25f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.GetComponent<ProjectileMovement>() != null) {
                score += collision.GetComponent<ProjectileMovement>().points;
                scoreBox.text = "Score: " + score;
            }
            Destroy(collision.gameObject);
        }
    }
}
