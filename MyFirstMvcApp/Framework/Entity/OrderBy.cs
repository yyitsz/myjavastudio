using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Framework.Entity
{
    public class OrderBy
    {
        private String propertyName;
        private Direction direction;

        public String PropertyName { get { return propertyName; } }
        public Direction Direction { get { return direction; } }

        public OrderBy()
        {

        }

        public OrderBy(String propertyName, Direction direction)
        {
            this.propertyName = propertyName;
            this.direction = direction;
        }

        public OrderBy SetDirection(Direction direction)
        {
            this.direction = direction;
            return this;

        }

        public OrderBy SetPropertyName(string propertyName)
        {
            this.propertyName = propertyName;
            return this;

        }

        public static OrderBy Create<T>(Expression<Func<T, String>> exp)
        {
            return Create<T>(exp, Framework.Entity.Direction.ASC);
        }
        public static OrderBy Create<T>(Expression<Func<T,String>> exp,Direction direction)
        {
            if (exp.Body is System.Linq.Expressions.MemberExpression)
            {

                return new OrderBy(((MemberExpression)exp.Body).Member.Name, direction);
            }
            else
            {
                throw new Exception("Does not support expresstion except MemberExpression.");
            }
        }
    }

    public enum Direction
    {
        ASC,
        DESC
    }
}
