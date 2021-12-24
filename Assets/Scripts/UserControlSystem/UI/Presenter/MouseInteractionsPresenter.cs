using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;


namespace UserControlSystem
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SelectableValue _selectedObject;

        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;

        private ISelectable _selectable;
        
        private RaycastHit[] _raycastHits = new RaycastHit[2];
        private int _raycastAmount;

        private LayerMask _layerMask = new LayerMask();

        private void Start()
        {
            _layerMask =LayerMask.GetMask("Building", "Unit");
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {
                return;
            }
            
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
            {
                _raycastAmount = Physics.RaycastNonAlloc(ray, _raycastHits, Mathf.Infinity, _layerMask);
            
                if (_raycastAmount == 0)
                {
                    _selectable = null;
                }
                else
                {
                    _selectable = _raycastHits[0].collider.GetComponentInParent<ISelectable>();
                }
            
                _selectedObject.SetValue(_selectable);
            }
            else
            {
                if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }
        }
    }
}