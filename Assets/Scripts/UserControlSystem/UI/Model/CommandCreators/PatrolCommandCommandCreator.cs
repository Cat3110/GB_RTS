using System;
using Abstractions;

namespace UserControlSystem.CommandCreators
{
    public class PatrolCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        protected override void classSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}