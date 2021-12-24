using Abstractions;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    { 
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"Move from core to {command.Target}");
            
        }
    }
}