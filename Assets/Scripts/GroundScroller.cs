using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] float speed;
    MeshRenderer meshRenderer;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (!BirdController.Hit)
            meshRenderer.material.mainTextureOffset = Vector2.right * Time.time * speed;
    }
}
