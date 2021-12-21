using UnityEngine;

namespace Abstractions
{
    public abstract class UnitBase : MonoBehaviour, ISelectable
    {
        public float Health { get; }
        public float MaxHealth { get; }
        public Sprite Icon { get; }
    }
}