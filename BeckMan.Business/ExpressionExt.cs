using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeckMan.Business
{
    public static class ExpressionExt
    {
        /// <summary>  
        /// 机关函数应用True时：单个AND有效，多个AND有效；单个OR无效，多个OR无效；混应时写在AND后的OR有效。即，设置为True时所有or语句应该放在and语句之后，否则无效  
        /// </summary>  
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        /// <summary>  
        /// 机关函数应用False时：单个AND无效，多个AND无效；单个OR有效，多个OR有效；混应时写在OR后面的AND有效。 即，设置为False时所有or语句应该放在and语句之前，否则无效  
        /// </summary>  
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1,
           Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters
                    .Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.Or(expression1.Body, invokedExpression),
            expression1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1,
              Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters
                 .Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body,
                   invokedExpression), expression1.Parameters);
        }


        //public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        //{
        //    // build parameter map (from parameters of second to parameters of first)  
        //    var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

        //    // replace parameters in the second lambda expression with parameters from the first  
        //    var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

        //    // apply composition of lambda expression bodies to parameters from the first expression   
        //    return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        //}

        //public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        //{
        //    return first.Compose(second, Expression.And);
        //}

        //public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        //{
        //    return first.Compose(second, Expression.Or);
        //}
    }

}
