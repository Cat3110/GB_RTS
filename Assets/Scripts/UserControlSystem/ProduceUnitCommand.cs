using Abstractions;
using UnityEngine;
using Utils.AssetsInjector;

namespace UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("TT_Swordman")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}