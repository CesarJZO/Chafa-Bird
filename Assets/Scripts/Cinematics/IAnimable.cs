using UnityEngine;

namespace Cinematics
{
    public interface IAnimable
    {
        void ChangeState(string state);

        void FaceDirection(float direction);

        void Idle(float direction);

        void MoveTo(Transform target);

        bool Animating { get; set; }
    }
}
