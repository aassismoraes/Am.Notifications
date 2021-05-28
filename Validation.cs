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
        public static double ValueIsLessOrEqualsThen(this double property,double minimunValue ,string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if(property <= minimunValue)
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
        public static double ValueIsBiggerOrEqualsThen(this double property,double maximumValue ,string errorMessage = null)
        {
            if (_uniqueMessage != null)
                errorMessage = _uniqueMessage;
            if (errorMessage == null)
                errorMessage = $"Field can not be '{property}'.";

            if(property >= maximumValue)
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
        public static string IsNullEmptyOrWhiteSpace(this string property, string errorMessage = null)
        {
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
