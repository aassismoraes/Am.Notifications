using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Am.Notifications
{
    /// <summary>
    /// Must be inherit by class
    /// </summary>
    public class Notifiable
    {
        private static List<Notification> _notifications = new List<Notification>();
        public bool invalid = false;
        public bool Invalid
        {
            get
            {

                if (invalid == true)
                    IsValid = false;

                return invalid;
            }
            set
            {


                invalid = value;
            }
        }

        private bool isValid = true;
        public bool IsValid
        {
            get
            {
                if (isValid == true)
                    Invalid = false;

                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        public bool IsBlocking { get; private set; } = false;
        public bool HasInvalidNotification { get; private set; } = false;
        public bool HasValidNotification { get; private set; } = false;

        public Notifiable()
        {
            Validation.SetClass(this);
        }

        /// <summary>
        /// Add a notification to object
        /// </summary>
        /// <param name="returnMessage">Message thats be retorned to client.</param>
        /// <param name="testedProperty">Ex. StringNullOrEmpty.</param>
        /// <param name="notificationType">Level of notification.</param>
        /// <param name="returnCode">Some internal error or info code.</param>
        /// <param name="statusCodeHttp">HttpStatusCode to return.</param>
        /// <param name="isBlocking">Determines if the notification is a blocking notification.</param>
        public void AddNotification(string returnMessage, string testedProperty = "",
            NotificationType notificationType = NotificationType.Error, string returnCode = "",
            HttpStatusCode statusCodeHttp = HttpStatusCode.UnprocessableEntity, bool isBlocking = false)
        {
            var notification = new Notification(returnMessage, testedProperty, notificationType, returnCode, statusCodeHttp);
            Notifications.AddNotification(returnMessage, testedProperty, notificationType, returnCode, statusCodeHttp);

            SetProperties(notificationType, isBlocking);

            _notifications.Add(notification);

        }

        /// <summary>
        /// Returns and clear this object notifications.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Notification> GetAndClearNotifications()
        {
            var notifications = new List<Notification>(_notifications);

            _notifications.Clear();

            ResetProperties();

            return notifications;
        }

        /// <summary>
        /// Returns and clear all notifications in the system.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Notification> GetAndClearAllNotifications()
        {
            var notifications = new List<Notification>(_notifications);

            _notifications.Clear();
            Notifications.GetAndClearNotifications();

            ResetProperties();

            return _notifications;
        }

        /// <summary>
        /// Returns this object notifications.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return _notifications;
        }

        /// <summary>
        /// True if this object has notifications.
        /// </summary>
        /// <returns></returns>
        public bool HasNotifications()
        {
            return _notifications.Count() > 0;
        }

        private void SetProperties(NotificationType notificationType, bool isBlocking)
        {
            IsBlocking = isBlocking;

            if (notificationType == NotificationType.Error)
            {
                Invalid = true;
                HasInvalidNotification = true;
            }
            else
            {
                Invalid = false;
                HasValidNotification = true;
            }
        }
        private void ResetProperties()
        {
            IsValid = true;
            Invalid = false;
            HasValidNotification = false;
            HasInvalidNotification = false;
            IsBlocking = false;
        }


    }

    public static class Notifications
    {
        private static List<Notification> _notifications = new List<Notification>();

        public static bool invalid = false;
        public static bool Invalid
        {
            get
            {

                if (invalid == true)
                    IsValid = false;

                return invalid;
            }
            set
            {

                invalid = value;
            }
        }

        private static bool isValid = true;
        public static bool IsValid
        {
            get
            {

                if (isValid == true)
                    Invalid = false;

                return isValid;
            }
            set
            {


                isValid = value;
            }
        }

        public static bool IsBlocking { get; private set; } = false;
        public static bool HasInvalidNotification { get; private set; } = false;
        public static bool HasValidNotification { get; private set; } = false;

        /// <summary>
        /// Add a notification to object
        /// </summary>
        /// <param name="returnMessage">Message thats be retorned to client.</param>
        /// <param name="testedProperty">Ex. StringNullOrEmpty.</param>
        /// <param name="notificationType">Level of notification.</param>
        /// <param name="returnCode">Some internal error or info code.</param>
        /// <param name="statusCodeHttp">HttpStatusCode to return.</param>
        /// <param name="isBlocking">Determines if the notification is a blocking notification.</param>
        public static void AddNotification(string returnMessage, string testedProperty = "",
            NotificationType notificationType = NotificationType.Error, string returnCode = "",
            HttpStatusCode statusCodeHttp = HttpStatusCode.UnprocessableEntity, bool isBlocking = false)
        {
            var notification = new Notification(returnMessage, testedProperty, notificationType, returnCode, statusCodeHttp);

            SetProperties(notificationType, isBlocking);

            _notifications.Add(notification);

        }

        /// <summary>
        /// Returns this object notifications.
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyCollection<Notification> GetNotifications()
        {
            return _notifications;
        }

        /// <summary>
        /// Returns and clear this object notifications.
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyCollection<Notification> GetAndClearNotifications()
        {
            var notifications = new List<Notification>(_notifications);

            _notifications.Clear();
            ResetProperties();

            return notifications;
        }

        /// <summary>
        /// True if this object has notifications.
        /// </summary>
        /// <returns></returns>
        public static bool HasNotifications()
        {
            return _notifications.Count() > 0;
        }

        public static ControllerBase Throw(this ControllerBase controllerBase, IEnumerable<object> _obj)
        {                       

            if (Notifications.HasNotifications())
            {
                var notification = Notifications.GetAndClearNotifications();
                var _statusCode = (int)notification.FirstOrDefault().StatusCodeHttp;

                controllerBase.StatusCode(_statusCode, notification);
            }

            if (_obj == null)
            {
                controllerBase.StatusCode(204);               
            }
           
            return controllerBase;         
        }

        private static void SetProperties(NotificationType notificationType, bool isBlocking)
        {
            IsBlocking = isBlocking;

            if (notificationType == NotificationType.Error)
            {
                Invalid = true;
                HasInvalidNotification = true;
            }
            else
            {
                Invalid = false;
                HasValidNotification = true;
            }
        }
        private static void ResetProperties()
        {
            IsValid = true;
            Invalid = false;
            HasValidNotification = false;
            HasInvalidNotification = false;
            IsBlocking = false;
        }
    }

    //Notification object
    public struct Notification
    {

        public string TestedProperty { get; private set; }
        public string ReturnCode { get; private set; }
        public HttpStatusCode StatusCodeHttp { get; private set; }
        public string ReturnMessage { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public bool IsBlocking { get; private set; }

        public Notification(string returnMessage, string testedProperty = "",
            NotificationType notificationType = NotificationType.Error, string returnCode = "",
            HttpStatusCode statusCodeHttp = HttpStatusCode.UnprocessableEntity, bool isBlocking = false)
        {
            ReturnMessage = returnMessage;
            TestedProperty = testedProperty;
            NotificationType = notificationType;
            ReturnCode = returnCode;
            StatusCodeHttp = statusCodeHttp;
            IsBlocking = isBlocking;
        }
    }

    public enum NotificationType
    {
        Info,
        Warning,
        Error
    }


}
