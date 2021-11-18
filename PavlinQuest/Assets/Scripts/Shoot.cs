using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject projectile;
    public float ammoReserve;
    public float ammoLoaded;

    public float shootForce;

    public AudioClip[] gunSounds;
    public AudioClip[] hurtSounds;
    public AudioClip reloadSound;
    public AudioClip deathSound;

    private double timeStamp;

    public float health;
    public bool isHit;

    public Animator animator;
    public Animator faceAnimator;

    public GameObject DeathScreen;

    private void Start()
    {
        health = 100f;
        timeStamp = Time.time;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && timeStamp <= Time.time && ammoLoaded != 0f)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                faceAnimator.Play("PavlinFace_Shoot");
                Shooting();
                ammoLoaded = ammoLoaded - 1;
                timeStamp = Time.time + 0.5;
                Debug.Log("ammo reserve" + ammoReserve.ToString());
                Debug.Log("ammo Loaded" + ammoLoaded.ToString());
            }
        }
        else if (ammoLoaded == 0f && ammoReserve != 0f)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                StartCoroutine(PlaySoundAndWait(reloadSound));
                animator.Play("Pavlin_Reload");

                ammoReserve = ammoReserve - 5f;
                ammoLoaded = ammoLoaded + 5f;
                Debug.Log("ammo reserve" + ammoReserve.ToString());
                Debug.Log("ammo Loaded" + ammoLoaded.ToString());
            }
        }
        else if (Input.GetButtonDown("Fire1") && ammoReserve == 0f)
        {
            return;
        }
    }

    IEnumerator PlaySoundAndWait(AudioClip sound)
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();

        yield return new WaitWhile(() => GetComponent<AudioSource>().isPlaying);
    }

    void Shooting()
    {
        StartCoroutine(PlaySoundAndWait(gunSounds[0]));

        GameObject bullet = Instantiate(projectile, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(FirePoint.up * shootForce, ForceMode2D.Impulse);
    }

    IEnumerator HardRestartGame()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(2);

        //Exit program
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            StartCoroutine(PlaySoundAndWait(hurtSounds[Random.Range(0,3)]));

            health -= 25;
            faceAnimator.Play("PavlinFace_Hit");
        }

        if (health <= 0f)
        {
            //Time.timeScale = 0f;
            DeathScreen.SetActive(true);
            StartCoroutine(PlaySoundAndWait(deathSound));
            StartCoroutine(HardRestartGame());
        }
    }


}