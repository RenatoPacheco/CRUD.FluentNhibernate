using CRUD.FluentNhibernate.Model.ValueObject;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.UserTypes
{
    public class StringAsDateDynamic : IUserType
    {
        #region IUserType Members

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public int GetHashCode(object x)
        {
            if (x == null)
                return 0;
            return x.GetHashCode();
        }
        public bool IsMutable
        {
            get { return false; }
        }

        // represents conversion on load-from-db operations:
        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            var obj = NHibernateUtil.String.NullSafeGet(rs, names[0]);
            if (obj == null)
                return null;
            DateDynamic value = null;
            try
            {
                if (obj is string)
                    value = DateDynamic.Parse(obj as string);
                else
                    value = (DateDynamic)obj;
            }
            catch (Exception)
            {
                return null;
            }
            return value;
        }

        // represents conversion on save-to-db operations:
        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                var text = (DateDynamic)value;
                ((IDataParameter)cmd.Parameters[index]).Value = text.ToString();
            }
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public Type ReturnedType
        {
            get { return typeof(DateDynamic); }
        }

        public NHibernate.SqlTypes.SqlType[] SqlTypes
        {
            get { return new[] { SqlTypeFactory.GetString(50) }; }
        }
        #endregion

        bool IUserType.Equals(object x, object y)
        {
            return object.Equals(x, y);
        }
    }
}
