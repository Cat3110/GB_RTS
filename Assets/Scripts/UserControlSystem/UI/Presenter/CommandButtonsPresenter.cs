using System;
using System.Collections.Generic;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.View;
using Utils.AssetsInjector;

namespace UserControlSystem
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;

        [SerializeField] private AssetsContext _context; 

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);

            _view.OnClick += onButtonClick;
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

        private void onButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }

            var attacker = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attacker != null)
            {
                attacker.ExecuteSpecificCommand(new AttackCommand());
                return;
            }
            
            var mover = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (mover != null)
            {
                mover.ExecuteSpecificCommand(new MoveCommand());
                return;
            }
            
            var patroller = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patroller != null)
            {
                patroller.ExecuteSpecificCommand(new PatrolCommand());
                return;
            }
            
            var stopper = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stopper != null)
            {
                stopper.ExecuteSpecificCommand(new StopCommand());
                return;
            }


            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}