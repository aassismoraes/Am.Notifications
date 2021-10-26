using Am.Notifications.ValueObjects;
using System;

namespace Am.Notifications
{
    public static class Validation
    {
        private static string _uniqueMessage;
        private static Notifiable _notifiable;

        public static void SetClass(Notifiable notifiable)
        {
            _notifiable = notifiable;
        }

        static Validation()
        {
            if (_notifiable == null)
                _notifiable = new Notifiable();
        }

        /// <summary>
        /// Will throw notification when property be less then informated value
        /// </summary>
        /// <param name="property"></param>
        /// <param name="minimunValue"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static double ValueIsLessOrEqualsThen(this double property, double minimunValue, string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (property <= minimunValue)
                _notifiable.AddNotification($"{errorMessage}", "ValueIsLessOrEqualsThen");

            _notifiable.ReturnNotifiable();
            return property;
        }
        /// <summary>
        /// Will throw notification when property be bigger then informated value
        /// </summary>
        /// <param name="property"></param>
        /// <param name="maximumValue"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static double ValueIsBiggerOrEqualsThen(this double property, double maximumValue, string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (property >= maximumValue)
                _notifiable.AddNotification($"{errorMessage}", "ValueIsBiggerOrEqualsThen");

            _notifiable.ReturnNotifiable();
            return property;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static string IsNullEmptyOrWhiteSpace(this string property, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (string.IsNullOrEmpty(property) || string.IsNullOrWhiteSpace(property))
                _notifiable.AddNotification($"{errorMessage}", "IsNullEmptyOrWhiteSpace");

            _notifiable.ReturnNotifiable();
            return property;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static string IsNotNumber(this string property, string errorMessage = null)
        {

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;

            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null) && !long.TryParse(property, out long value))
                _notifiable.AddNotification($"{errorMessage}", "IsNotNumber");


            _notifiable.ReturnNotifiable();
            return property;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="maxLengh"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static string IsTooBig(this string property, int maxLengh, string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null) && property.Length > maxLengh)
                _notifiable.AddNotification($"{errorMessage}", "IsTooBig");



            _notifiable.ReturnNotifiable();
            return property;
        }

        public static string Lengh(this string property, int lengh, string errorMessage = null, bool enabled = true )
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null) && property.Length != lengh)
                _notifiable.AddNotification($"{errorMessage}", "Lengh");



            _notifiable.ReturnNotifiable();
            return property;
        }

        public static string MaxLengh(this string property, int maxLengh, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null) && property.Length > maxLengh)
                _notifiable.AddNotification($"{errorMessage}", "MaxLengh");



            _notifiable.ReturnNotifiable();
            return property;
        }

        public static string MinLengh(this string property, int minLengh, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null) && property.Length < minLengh)
                _notifiable.AddNotification($"{errorMessage}", "MinLengh");



            _notifiable.ReturnNotifiable();
            return property;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static string IsNull(this string property, string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (property == null)
                _notifiable.AddNotification($"{errorMessage}", "IsNull");


            _notifiable.ReturnNotifiable();
            return property;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static string IsNullOrWhiteSpace(this string property, string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (string.IsNullOrWhiteSpace(property))
                _notifiable.AddNotification($"{errorMessage}", "IsNullOrWhiteSpace");


            _notifiable.ReturnNotifiable();
            return property;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static string SetUniqueMessage(this string property, string errorMessage)
        {
            _uniqueMessage = errorMessage;
            _notifiable.ReturnNotifiable();
            return property;
        }


        #region DateTime       

        public static DateTime DateTimeRange(this DateTime property, DateTime minDateTime, DateTime maxDateTime, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null))
            {
                if (property < minDateTime || property > maxDateTime)
                {
                    _notifiable.AddNotification($"{errorMessage}", "DateTimeRange");
                }
            }

            _notifiable.ReturnNotifiable();
            return property;
        }
        public static string DateTimeRange(this string property, string minDateTime, string maxDateTime, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if ((property != null))
            {
                var isPropertyConversible = DateTime.TryParse(property, out DateTime _property);
                var isMinDateTimeConversible = DateTime.TryParse(minDateTime, out DateTime _minDateTime);
                var isMaxDateTimeConversible = DateTime.TryParse(maxDateTime, out DateTime _maxDateTime);

                if (!isPropertyConversible || !isMinDateTimeConversible || !isMaxDateTimeConversible)
                {
                    _notifiable.AddNotification($"One or more values cannot convert to dateTime.", "DateTimeRange");
                    return property;
                }

                if (_property < _minDateTime || _property > _maxDateTime)
                {
                    _notifiable.AddNotification($"{errorMessage}", "DateTimeRange");
                }
            }

            _notifiable.ReturnNotifiable();
            return property;
        }

        #endregion

        #region Integer

        public static int MinValue(this int property, double minValue, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (property < minValue)
                _notifiable.AddNotification($"{errorMessage}", "MinValue");

            _notifiable.ReturnNotifiable();
            return property;
        }

        #endregion

        #region ValueObjects

        /// <summary>
        /// Valida um CNPJ
        /// </summary>
        /// <param name="property"></param>
        /// <param name="errorMessage">Mensagem de erro caso o CNPJ seja inválido</param>
        /// <returns></returns>
        public static string ValidCnpj(this string property, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (!Cnpj.TryParse(property, out var _cnpj))
            {
                _notifiable.AddNotification($"{errorMessage}", "ValidCnpj");
            }

            _notifiable.ReturnNotifiable();
            return _cnpj.ToString();
        }


        public static string ValidCpf(this string property, string errorMessage = null, bool enabled = true)
        {
            if (enabled == false)
                return property;

            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if (!Cpf.TryParse(property, out var _cpf))
            {
                _notifiable.AddNotification($"{errorMessage}", "ValidCpf");
            }

            _notifiable.ReturnNotifiable();
            return _cpf.ToString();
        }





        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifiable"></param>
        /// <returns></returns>
        public static Notifiable ReturnNotifiable(this Notifiable notifiable)
        {
            return notifiable;
        }
    }

}
