using System;
using System.Collections.Generic;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.View;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        
        [Inject] private CommandButtonsModel _model;
        
        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
            
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
        }

        private void onSelected(ISelectable selected)
        {
            if (_currentSelectable == selected)
            {
                return;
            }
            _currentSelectable = selected;
            _view.Clear();

            if (selected != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selected as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
    }
}