using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Rigidbody2D body;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        body.velocity = Vector2.left * speed;
    }
    void LateUpdate()
    {
        if (BirdController.Hit)
            body.velocity = Vector2.zero;
    }

}
