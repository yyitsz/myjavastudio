using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Transform;
using System.Reflection;

namespace Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class ConstructorTransformerAttribute : TransformerAttribute
    {

        public Type[] ConstrustorParameterType { get; set; }
        public ConstructorTransformerAttribute()
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {

        }
        #region Constructors
        public ConstructorTransformerAttribute(Type type0)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1 };
        }
        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3, Type type4)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
            Type type4, Type type5, Type type6, Type type7, Type type8, Type type9)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8, type9 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
           Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8, type9, type10 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
          Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8, type9, type10, type11 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
         Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
            , Type type12)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8, type9, type10, type11, type12 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
        Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
           , Type type12, Type type13)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 };
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
        Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
           , Type type12, Type type13, Type type14)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2, type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14};
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
       Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
          , Type type12, Type type13, Type type14, Type type15)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2,type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14,type15};
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
     Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
        , Type type12, Type type13, Type type14, Type type15, Type type16)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1,type2, type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14,type15,type16};
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
    Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
       , Type type12, Type type13, Type type14, Type type15, Type type16, Type type17)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2,type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14,type15,type16,type17};
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
   Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
      , Type type12, Type type13, Type type14, Type type15, Type type16, Type type17, Type type18)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1,type2, type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14,type15,type16,type17,type18};
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
  Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
     , Type type12, Type type13, Type type14, Type type15, Type type16, Type type17, Type type18, Type type19)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1, type2,type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14,type15,type16,type17,type18,type19};
        }

        public ConstructorTransformerAttribute(Type type0, Type type1, Type type2, Type type3,
  Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11
     , Type type12, Type type13, Type type14, Type type15, Type type16, Type type17, Type type18, Type type19, Type type20)
            : base(typeof(AliasToBeanConstructorResultTransformer))
        {
            ConstrustorParameterType = new Type[] { type0, type1,type2, type3, type4, type5, type6, type7, type8,
                type9, type10, type11, type12,type13 ,type14,type15,type16,type17,type18,type19,type20};
        }

        #endregion

        public override NHibernate.Transform.IResultTransformer CreateTransformer(MethodInfo calledmethod, Type returnType)
        {

            ConstructorInfo ctorInfo = null;
            if (ConstrustorParameterType != null && ConstrustorParameterType.Length > 0)
            {
                ctorInfo = returnType.GetConstructor(ConstrustorParameterType);

            }
            else
            {
                int count = 0;
                foreach (var item in returnType.GetConstructors())
                {
                    if (item.GetParameters().Length > 0)
                    {
                        ctorInfo = item;
                        count++;
                    }
                }

                if (count > 1)
                {
                    throw new Exception("Using ConstructorTransformerAttribute on method " + calledmethod.Name + " without parmatmer type must only one constructor(no default) in type " + returnType.FullName);
                }
            }
            if (ctorInfo == null)
            {
                throw new NotSupportedException("Using AliasToBeanConstructorResultTransformer can not find the proper constructor in method." + calledmethod.Name);
            }
            return new AliasToBeanConstructorResultTransformer(ctorInfo);
        }
    }
}
