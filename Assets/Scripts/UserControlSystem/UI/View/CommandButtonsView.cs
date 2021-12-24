using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public class CommandButtonsView : MonoBehaviour
    {
        public Action<ICommandExecutor> OnClick;
        
        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceUnitButton;

        private Dictionary<Type, GameObject> _buttonByExecutorType;

        private void Start()
        {
            _buttonByExecutorType = new Dictionary<Type, GameObject>();
            
            _buttonByExecutorType.Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonByExecutorType.Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonByExecutorType.Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonByExecutorType.Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
            _buttonByExecutorType.Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
        }
        
        public void BlockInteractions(ICommandExecutor commandExecutor)
        {
            UnblockAllInteractions();
            getButtonGameObjectByType(commandExecutor.GetType())
                .GetComponent<Selectable>().interactable = false;
        }
        
        public void UnblockAllInteractions() => SetInteractible(true);
        
        private void SetInteractible(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = _buttonByExecutorType
                    .First(type => type
                        .Key
                        .IsInstanceOfType(currentExecutor))
                    .Value;
                
                buttonGameObject.SetActive(true);

                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
            }
        }
        
        private GameObject getButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonByExecutorType
                .First(type => type.Key.IsAssignableFrom(executorInstanceType))
                .Value;
        }

        public void Clear()
        {
            foreach (var kvp in _buttonByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }
    }
}