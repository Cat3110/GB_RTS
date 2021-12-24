using System;
using Abstractions;

namespace UserControlSystem.CommandCreators
{
    public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        protected override void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}