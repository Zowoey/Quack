using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Animator anim;
    private Vector3 LastPosition;
    [Header("Camera Settings")]
    public float CameraSpeed;
    public AudioSource BreadPickup;

    public GameObject Activate;
    public GameObject PetActivate;

    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    IEnumerator PetDuck()
    {
        this.Activate.SetActive(false);
        this.PetActivate.SetActive(true);
        GameObject.Find("PettingHand").GetComponent<Animator>().SetTrigger("handPet");
        yield return new WaitForSeconds(2);
        this.PetActivate.SetActive(false);
        this.Activate.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MenuTag"))
        {
            return;
        }

        LastPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        Vector3 MovementVector = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            MovementVector.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovementVector.z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovementVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovementVector.x += 1;
        }

        MovementVector.Normalize();

        Quaternion rotation = this.transform.rotation;
        Matrix4x4 rTransform = Matrix4x4.Rotate(rotation);

        Vector3 newMovementVector = rTransform * MovementVector * Time.deltaTime * CameraSpeed;


        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (!Physics.SphereCast(transform.position, 0.5f, transform.TransformDirection(MovementVector), out hit, 0.1f, layerMask))
        {


            this.transform.position += newMovementVector;
        }
        else
        {
            if (hit.collider.gameObject.name == "Bread")
            {
                this.transform.position += newMovementVector;
                //Debug.Log("collision");
                BreadPickup.Play();
                GameObject.Find("Canvas").GetComponent<BreadDisplay>().breadCount += 20;
                Destroy(hit.collider.gameObject);

            }
        }
        if (Input.GetMouseButtonDown(1))
        {

            var Objects = Object.FindObjectsOfType<GameObject>();
            //find closest duck
            float closestDuck = 1000000;
            foreach (var Object in Objects)
            {
                if (Object.name.Contains("Duck"))
                {
                    var distance = Vector3.Distance(Object.transform.position, this.transform.position);
                    if (distance < closestDuck)
                    {
                        closestDuck = distance;
                    }
                }
            }
            if (closestDuck < 3)
            {
                StartCoroutine(this.PetDuck());
            }

        }

    }
}