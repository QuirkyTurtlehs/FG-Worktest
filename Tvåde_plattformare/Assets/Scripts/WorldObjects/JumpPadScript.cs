using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    [SerializeField] GameObject dogGameObject;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Dog")
        {
            DogController dog = dogGameObject.GetComponent<DogController>();

            dog.ModifyForce(2);
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Dog")
        {
            DogController dog = dogGameObject.GetComponent<DogController>();

            dog.ModifyForce(0.5F);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DogController dog = dogGameObject.GetComponent<DogController>();

        dog.ModifyOnGround();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DogController dog = dogGameObject.GetComponent<DogController>();

        dog.ModifyOnGround();
    }
}
