using System;
using Foundation;
using SelligentMobileiOS;
using UIKit;
using UserNotifications;
using UserNotificationsUI;


namespace NotificationContentExtension
{
    public partial class NotificationViewController : UIViewController, IUNNotificationContentExtension
    {
        protected NotificationViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any required interface initialization here.
        }

        public void DidReceiveNotification(UNNotification notification)
        {            
            var url = "https://mobile.slgnt.eu/MobilePush/api/";
            var clientID = "f06ff4cc-15c5-48b1-b405-d78dfc93f3de";
            var privateKey = "/5v3UKuFJ237PSOQy6BYtICR8+DaU/YWhjBz2JI3q8wrAIBCYt7eSWZith+sIFNWgQqdYdMx+EhYoZUa8NUsIw==";

            //  Create the SMManagerSetting instance
            var setting = SMManagerSetting.SettingWithUrl(url, clientID, privateKey);
            //Start sdk from extension
            SMManager.SharedInstance().StartExtensionWithSetting(setting);

            //sdk api to add buttons from banner
            SMManager.SharedInstance().DidReceiveNotification(notification);
            label.Text = notification.Request.Content.Body;
        }
    }
}
