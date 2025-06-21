using Shared.Interfaces;
using System.Reflection;

namespace AutoGenerator.Handler
{

    /// <summary>
    /// يوفر وظائف عامة لقراءة السمات (Attributes) المعرفة على الفئات أو خصائصها.
    /// </summary>
    public interface IAttributeHandler:ITBase
    {

        List<(PropertyInfo Property, List<object> AttributeProperties)> GetAttributeProperties<TAttribute>(Type entityModel, params string[] attributePropertiesName) 
            where TAttribute : Attribute;
        List<(PropertyInfo Property, List<(object Value, Type ValueType)>)> GetAttributePropertiesWithType<TAttribute>(
           Type entityModel, params string[] attributePropertiesName)
           where TAttribute : Attribute;
    }

    /// <summary>
    /// يوفر وظائف عامة لقراءة السمات (Attributes) المعرفة على الفئات أو خصائصها.
    /// </summary>
    public class AttributeHandler: IAttributeHandler
    {



        /// <summary>
        /// يستخرج قائمة بالخصائص العامة للنوع المحدد التي تحتوي على سمة معينة <typeparamref name="TAttribute"/>.
        /// كما يستخرج القيم النصية لخصائص السمة التي يتم تحديد أسمائها في <paramref name="attributePropertiesName"/>.
        /// </summary>
        /// <typeparam name="TAttribute">نوع السمة التي سيتم البحث عنها، ويجب أن ترث من <see cref="Attribute"/>.</typeparam>
        /// <param name="entityModel">نوع  الذي سيتم فحص خصائصه.</param>
        /// <param name="attributePropertiesName">أسماء خصائص داخل السمة <typeparamref name="TAttribute"/> التي سيتم استخراج قيمها (يمكن أن تكون أسماء لخاصيات نصية أو مجموعة نصوص).</param>
        /// <returns>
        /// قائمة من العناصر، كل عنصر يحتوي على: 
        /// <list type="bullet">
        /// <item><see cref="PropertyInfo"/> للخاصية التي تحمل السمة.</item>
        /// <item>قائمة من النصوص التي تم استخراجها من خصائص السمة المحددة في <paramref name="attributePropertiesName"/>.</item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// الدالة تدعم خصائص السمة التي تكون من نوع نص (string) أو مجموعة نصوص (<see cref="IEnumerable{string}"/>).
        /// تُستخدم هذه الدالة بشكل عام لاستخراج معلومات السمات (Attributes) المرتبطة بخصائص الكائن.
        /// </remarks>
        public List<(PropertyInfo Property, List<dynamic> AttributeProperties)> GetAttributeProperties<TAttribute>(
            Type entityModel, params string[] attributePropertiesName)
            where TAttribute : Attribute 
        {


            var result = new List<(PropertyInfo, List<dynamic>)>();
            var props = entityModel.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<TAttribute>();
                List<dynamic> values = new();

                if (attributePropertiesName != null && attributePropertiesName.Any())
                {
                    foreach (var propertyName in attributePropertiesName)
                    {
                        var attrProp = typeof(TAttribute).GetProperty(propertyName);

                        if (attrProp != null)
                        {
                            var value = attrProp.GetValue(attr);

                            if (value != null)
                            {
                                if (value is IEnumerable<object> collection && value is not string)
                                    values.AddRange(collection);
                                else
                                    values.Add(value);
                            }
}
                    }
                }

                result.Add((prop, values));
            }

            return result;
        }
        public List<(PropertyInfo Property, List<(object Value, Type ValueType)>)> GetAttributePropertiesWithType<TAttribute>(
            Type entityModel, params string[] attributePropertiesName)
            where TAttribute : Attribute
        {
            var result = new List<(PropertyInfo, List<(object Value, Type ValueType)>)>();

            var props = entityModel.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<TAttribute>();
                var values = new List<(object, Type)>();

                if (attributePropertiesName != null && attributePropertiesName.Any())
                {
                    foreach (var propertyName in attributePropertiesName)
                    {
                        var attrProp = typeof(TAttribute).GetProperty(propertyName);
                        if (attrProp != null)
                        {
                            var value = attrProp.GetValue(attr);
                            if (value != null)
                            {
                                // إذا كانت القيمة مصفوفة أو قائمة، نضيف كل عنصر مع نوعه
                                if (value is IEnumerable<object> collection && value is not string)
                                {
                                    foreach (var item in collection)
                                    {
                                        if (item != null)
                                            values.Add((item, item.GetType()));
                                    }
                                }
                                else
                                {
                                    values.Add((value, value.GetType()));
                                }
                            }
                        }
                    }
                }

                result.Add((prop, values));
            }

            return result;
        }


        //public List<(PropertyInfo Property,List<object> AttributeProperties)> GetProperties<TAttribute>(Type typeClass,params string[] attributePropertiesName)
        //    where TAttribute : Attribute
        //    {
        //        var result = new List<(PropertyInfo, List<object>)>();

        //        var props = typeClass.GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //            .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));


        //        foreach (var prop in props)
        //        {
        //            var attr = prop.GetCustomAttribute<TAttribute>();

        //            List<object> alias =new();

        //            if (attributePropertiesName != null && attributePropertiesName.Any())
        //            {
        //                foreach (var property in attributePropertiesName)
        //                {
        //                    var aliasProp = typeof(TAttribute).GetProperty(property);

        //                    if (aliasProp != null)
        //                    {

        //                        var value = aliasProp.GetValue(attr);

        //                        if (value is string stringValue && !string.IsNullOrWhiteSpace(stringValue))
        //                        {
        //                            alias.Add(stringValue);
        //                        }
        //                        else if (value is IEnumerable<string> stringEnumerable)
        //                        {
        //                            alias.AddRange(stringEnumerable.Where(s => !string.IsNullOrWhiteSpace(s)));
        //                        }

        //                    }

        //                }
        //            }


        //            result.Add((prop, alias));
        //        }

        //        return result;
        //    }





    }
}
