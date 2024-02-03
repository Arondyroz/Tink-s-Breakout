using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public int turretID;
    private Transform bulletPoint;
    private float cooldown;
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        bulletPoint = this.gameObject.transform.GetChild(0);
        cooldown = Random.Range(4, 10);
        cooldownTimer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.instance.isDead == false && PlayerMovement.instance.startGame == true)
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        cooldown = Random.Range(3, 10);
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else 
        {
            cooldownTimer = cooldown;
            GameObject tempBullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            Rigidbody2D tempBulletRb = tempBullet.GetComponent<Rigidbody2D>();
            AudioSource tempBulletClip = tempBullet.GetComponent<AudioSource>();

            tempBulletClip.Play();

            tempBulletRb.AddForce(bulletPoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}