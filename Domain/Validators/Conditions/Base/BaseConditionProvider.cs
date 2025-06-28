using WasmAI.ConditionChecker.Checker;
using WasmAI.ConditionChecker.Base;
using System;

namespace Domain.Validators.Conditions.Base
{

    /// <summary>
    /// Provides a base implementation of a condition provider that manages a collection of conditions
    /// associated with enumeration-based keys of type <typeparamref name="ETStatus"/>.
    /// </summary>
    /// <typeparam name="ETStatus">An enumeration type used to identify different condition categories.</typeparam>
    /// <remarks>
    /// This class maintains an internal dictionary that maps enum values to corresponding <see cref="ICondition"/> instances.
    /// It provides various methods to:
    /// - Register and retrieve conditions by their enum type.
    /// - Evaluate conditions synchronously and asynchronously against given context data.
    /// - Query conditions that pass based on the provided context.
    /// - Filter conditions using predicates and support different retrieval scenarios.
    ///
    /// The evaluation methods may block on asynchronous operations internally, so use the async versions when possible.
    /// This base provider can be extended to add custom condition handling logic specific to application requirements.
    /// </remarks>
    public class BaseConditionProvider<ETStatus> : IConditionProvider<ETStatus> where ETStatus : Enum
    {
        private readonly Dictionary<ETStatus, ICondition> _conditions = new();

        public IEnumerable<ConditionResult> AnyPass(object context)
        {
            if (_conditions == null || _conditions.Count == 0)
                yield break;


            foreach (var condition in _conditions.Select(cList => cList.Value))
            {
                var result = condition.Evaluate(context).Result;

                if (result?.Success == true)
                    yield return result;
            }
            
        }
        public IEnumerable<ConditionResult> AnyPass(object[] contexts)
        {
            if (_conditions == null || _conditions.Count == 0)
                yield break;

            foreach (var context in contexts)
            {
                foreach (var condition in _conditions.Select(cList => cList.Value))
                {
                    var result = condition.Evaluate(context).Result;
                    if (result?.Success==true)
                        yield return result;
                }
            }
        }

       

        public async Task<ConditionResult> Check(ETStatus type, object context)
        {
            if (_conditions == null  || context==null)
                return null;

            var conditionsForType = GetConditions(type);
         
            if (conditionsForType.Any())
            {
  
                foreach (var condition in conditionsForType)
                {
                    var result =await condition.Evaluate(context);  
                    if (result.Success == true)
                    {
                        return result;
                     
                    }
                }
            }
            return ConditionResult.ToFailure("not found!!");
        }
        

        public ICondition? Get(ETStatus type)
        {
            if (_conditions == null || !_conditions.TryGetValue(type, out var conditions))
                return null;

            return conditions; 
        }


        public IEnumerable<ICondition> GetAllConditions()
        {
            if (_conditions == null)
                return Enumerable.Empty<ICondition>();

           return _conditions.Select(x => x.Value);
        }
        public IEnumerable<ICondition> GetConditions(object context)
        {
            if (_conditions == null || context==null)
                return Enumerable.Empty<ICondition>();

 
 
            var allConditions = _conditions.Select(x => x.Value);

            var applicableConditions = allConditions.Where(condition =>
            {
                try
                {

                    var resultTask = condition.Evaluate(context).Result;
                 
                    return resultTask?.Success==true;
                }
                catch
                {
                    return false;
                }
            });

            return applicableConditions;
        }



        public IEnumerable<ICondition> GetConditions(ETStatus type)
        {
            if (_conditions == null || !_conditions.ContainsKey(type))
                return Enumerable.Empty<ICondition>();

            return _conditions
                .Where(kvp => kvp.Key.Equals(type))
                .Select(kvp => kvp.Value);
        }

        public IEnumerable<ICondition> GetConditions(ETStatus type, object context)
        {
            if (_conditions?.Any() ==false || context == null)
                yield break;

            var conditionsForType = GetConditions(type);
            if (conditionsForType.Any())
            {
       
                foreach (var condition in conditionsForType)
                {
                    var result=condition.Evaluate(context).Result;  
                    if (result.Success == true)
                    {
                        yield return condition;
             
                    }
                }
            }
           
        }

        public IEnumerable<ICondition> GetConditions(ETStatus type, object context, Func<ICondition, bool> predicate)
        {

            var conditionsForType = GetConditions(type, context);

            if (conditionsForType.Any() && predicate != null)
                conditionsForType = conditionsForType.Where(predicate);
            

            return conditionsForType;
        }

        public IEnumerable<ICondition> GetConditions(ETStatus type, object context, Func<ICondition, bool> predicate, bool includeInactive)
        {
            var conditionsForType = GetConditions(type, context, predicate);
            return conditionsForType;
        }


        public IEnumerable<ETStatus> GetConditionTypes()
        {
            if (_conditions==null || !_conditions.Any())
                return Enumerable.Empty<ETStatus>();

            return _conditions.Select(x => x.Key);
        }

        public IEnumerable<ETStatus> GetConditionTypes(ICondition condition)
        {
            if (_conditions?.Any() == false || condition == null)
                return Enumerable.Empty<ETStatus>();

            return _conditions
                     .Where(x => x.Value.Equals(condition))
                     .Select(x => x.Key);
                    

        }

        public void Register(ETStatus type, ICondition condition)
        {
            if (type == null || condition == null)
                return;

            if (!_conditions.ContainsKey(type)) 
                _conditions.Add(type, condition);
            else
                _conditions[type] = condition;
        }

        public IEnumerable<ICondition> Where(Func<ICondition, bool> predicate)
        {
            if (_conditions?.Any() == false || predicate == null)
                return Enumerable.Empty<ICondition>();

            return _conditions
                      .Where(x => predicate(x.Value))
                      .Select(x => x.Value);
        }
    }
}
