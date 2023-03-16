using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet
{
    public GameObject bullet;

    public float age;
    public Bullet(GameObject bullet)
    {
        this.bullet = bullet;
        this.age = 0;
    }

}

public class BreadBullet : MonoBehaviour
{

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float BulletSpeed;

    List<Bullet> bullets = new List<Bullet>();

    // Start is called before the first frame update
    public AudioSource quackSound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MenuTag"))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            var gobj = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
            Bullet NewBullet = new Bullet(gobj);
            bullets.Add(NewBullet);
        }

        GameObject[] ducks = GameObject.FindGameObjectsWithTag("Duck");


        List<int> destroyed = new List<int>();
        for (var i = 0; i < bullets.Count; i++)
        {
            Bullet bullet = bullets[i];

            Vector3 forward = bullet.bullet.transform.forward;

            bullet.bullet.transform.position += forward * BulletSpeed * Time.deltaTime;

            bullet.age = bullet.age + Time.deltaTime;
            if (bullet.age > 2)
            {
                Destroy(bullet.bullet);
                destroyed.Add(i);
                continue;
            }

            foreach (var duck in ducks)
            {
                float distance = Vector3.Distance(duck.transform.position, bullet.bullet.transform.position);
                if (distance < 0.5)
                {
                    quackSound.Play();
                    Destroy(bullet.bullet);
                    destroyed.Add(i);
                    Destroy(duck);

                    break;
                }
            }


        }
        destroyed.Reverse();
        foreach (var i in destroyed)
        {
            bullets.RemoveAt(i);
        }

    }
}
