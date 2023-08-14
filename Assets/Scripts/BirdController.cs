using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static bool Hit { get; private set; } = false;
    [SerializeField] float peakForce = 8;
    [SerializeField] float dieStrength = 5;
    public ScoreSystem score;
    float strength;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // todo: use InputSystem
        // if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
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
        if (!Hit)
            Die();
        Hit = true;
    }

    void Die()
    {
        score.ResetScore();
        rb.constraints = RigidbodyConstraints2D.None;
        float x = Random.Range(-1, 1);
        rb.AddForce(new Vector2(x, 1) * dieStrength, ForceMode2D.Impulse);
    }
}
