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

        private ISelectable _selectable;
        
        private RaycastHit[] _raycastHits = new RaycastHit[2];
        private int _raycastAmount;

        private LayerMask _layerMask = new LayerMask();

        private void Start()
        {
            _layerMask =LayerMask.GetMask("Building", "Unit");
        }

        private void Update()
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }
            
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }
            
            _raycastAmount = Physics.RaycastNonAlloc(_camera.ScreenPointToRay(Input.mousePosition), _raycastHits, Mathf.Infinity, _layerMask);
            
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
    }
}