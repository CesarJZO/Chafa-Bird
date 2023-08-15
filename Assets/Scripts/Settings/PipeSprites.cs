using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "Pipe Colors", menuName = "Settings/Pipe Colors")]
    public class PipeSprites : ScriptableObject
    {
        [SerializeField] private Sprite green;
        [SerializeField] private Sprite red;
        [SerializeField] private Sprite yellow;
        [SerializeField] private Sprite blue;
        [SerializeField] private Sprite gray;

        public Sprite GetSprite(PipeColor pipeColor)
        {
            return pipeColor switch
            {
                PipeColor.Green => green,
                PipeColor.Red => red,
                PipeColor.Yellow => yellow,
                PipeColor.Blue => blue,
                _ => gray
            };
        }
    }
}
