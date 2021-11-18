using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // ai vars
    public GameObject[] PathNodes;
    public float speed;
    public bool isInRoom;
    public GameObject player;
    public GameObject me;
    public float hp;
    public GameObject explosionPrefab;

    // shooting vars
    public Transform FirePoint;
    public GameObject projectile;
    public AudioClip shootSound;
    public float shootForce;
    private double timeStamp;
    private int shootCountCooldown;

    // private movement ai vars
    private int currentNode;
    private bool reverseRoute;
    private float rotationAngle;

    void Start()
    {
        currentNode = 0;
        reverseRoute = false;
        isInRoom = false;
        shootCountCooldown = 0;

        timeStamp = Time.time;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, PathNodes[currentNode].transform.position, speed * Time.deltaTime);

        //Checks player presence to rotate and shoot
        if (isInRoom == true)
        {
            GetComponent<AudioSource>().enabled = true;

            Vector3 targetDir = player.transform.position - transform.position;
            rotationAngle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;
            transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

            if (timeStamp <= Time.time && shootCountCooldown <= 5)
            {
                Shooting();
                timeStamp = Time.time + 0.7;
                shootCountCooldown++;
            }
            else if (timeStamp <= Time.time && shootCountCooldown >= 6)
            {
                shootCountCooldown = 0;
                timeStamp = Time.time + 1.4;
            }
        }

        else
        {
            Vector3 targetDir = PathNodes[currentNode].transform.position - transform.position;
            rotationAngle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;

            transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        }
    }

    

    void Shooting()
    {
        GetComponent<AudioSource>().Play();

        GameObject bullet = Instantiate(projectile, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(FirePoint.up * shootForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
            hp -= 1f;

        if (hp <= 0f)
        {
            Vector2 instantiatePoint = collision.GetContact(0).point;
            Instantiate(explosionPrefab, instantiatePoint, Quaternion.identity);
            Destroy(me);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PathNode")
        {
            if (currentNode == 0)
                reverseRoute = false;

            else if (currentNode == PathNodes.Length - 1)
                reverseRoute = true;

            switch (reverseRoute)
            {
                case false:
                    currentNode++;
                    break;
                case true:
                    currentNode--;
                    break;
            }
        }
    }
}
 