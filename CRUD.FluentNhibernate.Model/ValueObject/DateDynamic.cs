using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CRUD.FluentNhibernate.Model.ValueObject
{
    public class DateDynamic
    {
        string Value { get; set; }

        public DateDynamic(string value)
        {
            if(Convert(value) != null)
                this.Value = value;
        }

        public DateDynamic(DateTime value)
        {
                this.Value = value.ToShortDateString();
        }

        private DateTime Convert(object value)
        {
            return Convert(value, DateTime.Now);
        }
        private DateTime Convert(object value, DateTime now)
        {
            DateTime resultado = new DateTime();
            string valor = null;
            string[] valores = null;
            DateTime data = DateTime.Now;
            string patternDiff = @"^\{[+-]{0,1}[0-9]+\}$";
            string pattern = @"^([0-9]{1,2}|\{[+-]{0,1}[0-9]+\})/([0-9]{1,2}|\{[+-]{0,1}[0-9]+\})/([0-9]{4}|\{[+-]{0,1}[0-9]+\})$";
            int diffDia = 0;
            int diffMes = 0;
            int diffAno = 0;

            if(object.Equals(value, null))
                return resultado;

            try
            {
                valor = System.Convert.ToString(value);
                if (string.IsNullOrEmpty(valor))
                    return new DateTime();

                if (!Regex.IsMatch(valor, pattern))
                    throw new Exception();

                valores = valor.Split('/');
                valor = string.Empty;
                for (int i = 0; i < valores.Length; i++)
                {
                    if (Regex.IsMatch(valores[i], patternDiff))
                    {
                        valores[i] = Regex.Replace(valores[i], @"{|}", "");
                        switch (i)
                        {
                            case 0:
                                diffDia = int.Parse(valores[i]);
                                valores[i] = now.Day.ToString();
                                break;
                            case 1:
                                diffMes = int.Parse(valores[i]);
                                valores[i] = now.Month.ToString();
                                break;
                            case 2:
                                diffAno = int.Parse(valores[i]);
                                valores[i] = now.Year.ToString();
                                break;
                        }
                    }
                    valor = valor + "/" + valores[i];
                }
                resultado = DateTime.Parse(valor.Substring(1));
                resultado = resultado.AddDays(diffDia).AddMonths(diffMes).AddYears(diffAno);
            }
            catch
            {
                throw new Exception(string.Format("Não foi possível converter {0} para {1}", value.GetType(), typeof(DateDynamic)));
            }

            return resultado;
        }
        
        public override string ToString()
        {
            return this.Value;
        }

        public DateTime ToDateTime()
        {
            return Convert(this.Value, DateTime.Now);
        }

        public DateTime ToDateTime(DateTime now)
        {
            return Convert(this.Value, now);
        }

        public static DateDynamic Parse(string value)
        {
            DateDynamic resultado = new DateDynamic(value);

            return resultado;
        }

        public static DateDynamic Parse(DateTime value)
        {
            DateDynamic resultado = new DateDynamic(value);

            return resultado;
        }

        public static bool TryParse(string value, out DateDynamic instance)
        {
            bool resultado = false;
            try
            {
                instance = Parse(value);
                resultado = true;
            }
            catch
            {
                instance = null;
                resultado = false;
            }
            return resultado;
        }

        public static bool TryParse(DateTime value, out DateDynamic instance)
        {
            bool resultado = false;
            try
            {
                instance = Parse(value);
                resultado = true;
            }
            catch
            {
                instance = null;
                resultado = false;
            }
            return resultado;
        }

        public static implicit operator DateDynamic(string value)
        {
            DateDynamic resultado = null;

            if (value != null)
                resultado = new DateDynamic(value);

            return resultado;
        }
        
        public static implicit operator DateDynamic(DateTime value)
        {
            DateDynamic resultado = null;

            if (value != null)
                resultado = new DateDynamic(value);

            return resultado;
        }

        public static explicit operator string(DateDynamic value)
        {
            string resultado = null;

            if (!object.Equals(value, null))
                resultado = value.ToString();

            return resultado;
        }

        public static explicit operator DateTime(DateDynamic value)
        {
            DateTime resultado = new DateTime();

            resultado = value.ToDateTime();

            return resultado;
        }
    }
}
