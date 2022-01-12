using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    public float speed = 5;
    public float duration = 7;
    void Start()
    {
        Destroy(gameObject, duration);
    }
    void Update()
    {
        if (!BirdController.Hit) {
            Debug.Log("Ouch!");
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
