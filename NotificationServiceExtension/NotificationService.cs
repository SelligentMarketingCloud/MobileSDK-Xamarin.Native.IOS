using System;
using Foundation;
using SelligentMobileiOS;
using UIKit;
using UserNotifications;

namespace NotificationServiceExtension
{
    [Register("NotificationService")]
    public class NotificationService : UNNotificationServiceExtension
    {
        Action<UNNotificationContent> ContentHandler { get; set; }
        UNMutableNotificationContent BestAttemptContent { get; set; }

        protected NotificationService(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
        {
            // Init and start the sdk.
            var url = "https://mobile.slgnt.eu/MobilePush/api/";
            var clientID = "f06ff4cc-15c5-48b1-b405-d78dfc93f3de";
            var privateKey = "/5v3UKuFJ237PSOQy6BYtICR8+DaU/YWhjBz2JI3q8wrAIBCYt7eSWZith+sIFNWgQqdYdMx+EhYoZUa8NUsIw==";

            //  Create the SMManagerSetting instance
            var setting = SMManagerSetting.SettingWithUrl(url, clientID, privateKey);

            //Start sdk from extension
            SMManager.SharedInstance().StartExtensionWithSetting(setting);

            //FROM HERE YOU WILL HAVE TO CHOOSE THE POSSIBLE IMPLEMENTATION THAT CORRESPOND BETTER TO YOUR NEEDS

            // FIRST implementation - manage the call to the block, which is executed with the modified notification content.
            //Provide the request with the original notification content to the sdk and return the updated notification content
            //  bestAttemptContent = SMManager.sharedInstance().didReceive(request)

            //call the completion handler when done.
            //contentHandler(bestAttemptContent!)

            // SECOND implementation - let the library manage this for you.
            //Provide the request with the original notification content to the sdk and the contentHandler.
            SMManager.SharedInstance().DidReceiveNotificationRequest(request, contentHandler);
        }

        public override void TimeWillExpire()
        {
            //FROM HERE YOU WILL HAVE TO CHOOSE THE SOLUTION THAT CORRESPOND BETTER TO YOUR NEEDS

            // FIRST implementation - manage the call to the block, which is executed with the modified notification content
            //    if let contentHandler = contentHandler,
            //      let bestAttemptContent = bestAttemptContent {

            // Mark the message as still encrypted.
            //        bestAttemptContent.subtitle = "(Encrypted)"
            //      bestAttemptContent.body = ""
            //     contentHandler(bestAttemptContent)
            // }

            // SECOND implementation - let the library manage this for you.
            SMManager.SharedInstance().ServiceExtensionTimeWillExpire();
        }
    }
}
