using System.Collections.Generic;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.View;

namespace UserControlSystem
{
    public class OutlinePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;

        private ISelectable _currentSelected;
        private OutlineView _outlineView;
        private void Start()
        {
            _selectedValue.OnSelected += onSelected;
            onSelected(_selectedValue.CurrentValue);
        }

        private void onSelected(ISelectable selected)
        {
            if (_currentSelected == selected)
            {
                return;
            }

            if (selected == null)
            {
                _outlineView = (_currentSelected as Component)?.GetComponentInParent<OutlineView>();
                _outlineView.OutlineDisable();
                _currentSelected = null;
                return;
            }

            _currentSelected = selected;
            _outlineView = (_currentSelected as Component)?.GetComponentInParent<OutlineView>();
            _outlineView.OutlineEnable();
        }
    }
}