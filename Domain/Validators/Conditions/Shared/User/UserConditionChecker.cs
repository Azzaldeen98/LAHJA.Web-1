using Domain.Validators.Conditions.Shared;
using Shared.Interfaces;
using WasmAI.ConditionChecker.Checker;

namespace Domain.Validators.Conditions.Shared.User
{
    public interface IUserConditionChecker: ISharedConditionChecker , ITScope
    {

    }

    public class UserConditionChecker : BaseConditionChecker, IUserConditionChecker
    {


    }
}
