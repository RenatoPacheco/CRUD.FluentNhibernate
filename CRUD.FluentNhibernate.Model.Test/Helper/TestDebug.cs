using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace CRUD.FluentNhibernate.Model.Test.Helper
{
    public class TestDebug
    {
        /// <summary>
        /// Mostra as propriedades de um objeto e seus devidos valores no output do teste.
        /// </summary>
        /// <param name="valor">Objeto a ser exibido os dados</param>
        public static void MostraDados(object valor)
        {
            foreach(PropertyInfo info in valor.GetType().GetProperties())
            {
                if (info.CanRead)
                {
                    Debug.WriteLine(string.Format("{0} : {1}", info.Name, info.GetValue(valor, null)));
                }
            }
        }
    }
}
