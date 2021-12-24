using System;
using Abstractions;

namespace UserControlSystem.CommandCreators
{
    public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
    {
        protected override void classSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}