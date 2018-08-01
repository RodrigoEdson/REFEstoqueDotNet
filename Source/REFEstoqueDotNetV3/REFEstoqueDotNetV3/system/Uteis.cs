using System;
using REFEstoqueDotNetV3.exceptions;
using System.Globalization;


namespace REFEstoqueDotNetV3.system
{
    public static class Uteis
    {
        public static int stringToInt(string t)
        {
            try
            {
                return (t != null && t != "") ? Convert.ToInt32(t) : 0;
            }
            catch (FormatException e)
            {
                throw new InvalidPropertyValueException("Valor " + t + " não é um número válido", e);
            }
        }

        public static double stringToDouble(string t)
        {
            try
            {
                NumberFormatInfo provider = new NumberFormatInfo();

                provider.NumberDecimalSeparator = ",";
                provider.NumberGroupSeparator = ".";
                provider.NumberGroupSizes = new int[] { 3 };

                return (t != null && t != "") ? Convert.ToDouble(t, provider) : 0;
            }
            catch (FormatException e)
            {
                throw new InvalidPropertyValueException("Valor " + t + " não é um número decimal válido", e);
            }
        }
    }
}
