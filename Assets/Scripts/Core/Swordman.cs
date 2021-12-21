using Abstractions;
using UnityEngine;

namespace Core
{
    public class Swordman : UnitBase
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;

        private float health = 100;
    }
}