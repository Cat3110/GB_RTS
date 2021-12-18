using System.Linq;
using UnityEngine;


namespace UserControlSystem.UI.View
{
    public class OutlineView : MonoBehaviour
    {
        [SerializeField] private Material _outlineMaskMaterial;
        [SerializeField] private Material _outlineFillMaterial;

        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        public void OutlineEnable()
        {
            var materials = _renderer.sharedMaterials.ToList();

            materials.Add(_outlineMaskMaterial);
            materials.Add(_outlineFillMaterial);

            _renderer.materials = materials.ToArray();
        }

        public void OutlineDisable()
        {
            var materials = _renderer.sharedMaterials.ToList();

            materials.Remove(_outlineMaskMaterial);
            materials.Remove(_outlineFillMaterial);

            _renderer.materials = materials.ToArray();
        }
    }
}