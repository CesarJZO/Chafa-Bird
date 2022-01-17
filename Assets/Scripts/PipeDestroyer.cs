using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}