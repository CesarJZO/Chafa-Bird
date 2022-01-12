using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static bool Hit { get; private set; } = false;
    public float peakForce = 8;
    public ScoreSystem score;
    float strength;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            float y = rb.velocity.y;
            // strength = peakForce * Mathf.Exp((y * -y) / 50);
            strength = peakForce - y;
            // Debug.Log($"f({y}) = {strength}");
            rb.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        score.UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        score.ResetScore();
        Hit = true;
    }


}
