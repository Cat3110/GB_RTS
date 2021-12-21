using Abstractions;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class HoldCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Hold from core");
        }
    }
}