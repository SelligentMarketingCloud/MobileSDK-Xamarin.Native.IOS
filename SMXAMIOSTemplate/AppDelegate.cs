using Foundation;
using UIKit;
using SelligentMobileiOS;
using UserNotifications;
using ObjCRuntime;
using System;
using CoreFoundation;
using System.Collections;
using System.Collections.Generic;

namespace testApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate, IUNUserNotificationCenterDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {

            UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            center.Delegate = this;

            //  Don't forget to put -ObjC in Project > Build Settings > Other Linker Flags

            var url = "https://mobile.slgnt.eu/MobilePush/api/";
            var clientId = "CLIENTID";
            var key = "KEY";

            // Then:
            //  Create the SMManagerSetting instance
            SMManagerSetting setting = SMManagerSetting.SettingWithUrl(url, clientId, key);

            //Optional - Default value is true
            setting.ShouldClearBadge = true;
            setting.ShouldDisplayRemoteNotification = true;

            //Optional - Default value is kSMClearCache_Auto
            setting.ClearCacheIntervalValue = SMClearCache.Auto;

            // Initialise InApp Message settings - other constructors exist (cf. documentation)
            SMManagerSettingIAM iamSetting = SMManagerSettingIAM.SettingWithRefreshType(SMInAppRefreshType.Minutely,false);

            setting.ConfigureInAppMessageServiceWithSetting(iamSetting);

            // Initialise InApp Content settings - other constructors exist (cf. documentation)
            SMManagerSettingIAC iacSetting = SMManagerSettingIAC.SettingWithRefreshType(SMInAppRefreshType.Minutely);

            setting.ConfigureInAppContentServiceWithSetting(iacSetting);

            //Initialise location services - You need plot projects framework (not available in this template project)  and plotconfig.json file in your app to be able to use this - cf. documentation for more information on all available features
            setting.ConfigureLocationService();

            SMManager.SharedInstance().StartWithLaunchOptions(launchOptions, setting);

            // The following commands can be done later depending the needs of your app
            SMManager.SharedInstance().EnableInAppMessage(true);
            SMManager.SharedInstance().RegisterForRemoteNotification(); // this displays the dialog box for user to let him allow the reception of push notifications

            //Listen to differents broadcasting
            //InAppMessage broadcasting
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("anyMethodNameDidReceiveInAppMessage:"), SelligentMobileiOS.Constants.kSMNotification_Event_DidReceiveInAppMessage, null);

            //InAppContent broadcasting
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("anyMethodNameDidReceiveInAppContent:"), SelligentMobileiOS.Constants.kSMNotification_Event_DidReceiveInAppContent, null);

            //Other available braodcastings - check documentation for more informations
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("anyMethodNameButtonClicked:"), SelligentMobileiOS.Constants.kSMNotification_Event_ButtonClicked, null);
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("anyMethodNameWillDisplayNotification:"), SelligentMobileiOS.Constants.kSMNotification_Event_WillDisplayNotification, null);
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("anyMethodNameWillDismissNotification:"), SelligentMobileiOS.Constants.kSMNotification_Event_WillDismissNotification, null);
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("anyMethodNameDidReceiveRemoteNotification:"), SelligentMobileiOS.Constants.kSMNotification_Event_DidReceiveRemoteNotification, null);

            //When using a selligent push notification button with a button open method in app (this can be listened anywhere in your app)
            //"CustomActionBroadcastEvent" is an example it can be any string but it must match exactly the value you will set for the button in the push
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("customAction"), new NSString("CustomActionBroadcastEvent:"), null);

            return true;
        }

       
        [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
        public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            SMManager.SharedInstance().DidRegisterForRemoteNotificationsWithDeviceToken(deviceToken);
        }
        [Export("application:didRegisterUserNotificationSettings:")]
        public void DidRegisterUserNotificationSettings(UIApplication application, UIUserNotificationSettings notificationSettings)
        {
            SMManager.SharedInstance().DidRegisterUserNotificationSettings(notificationSettings);
        }        

        [Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
        public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            SMManager.SharedInstance().DidFailToRegisterForRemoteNotificationsWithError(error);
        }        

        [Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
        public void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            SMManager.SharedInstance().DidReceiveRemoteNotification(userInfo,completionHandler);
        }        

        [Export("applicationDidBecomeActive:")]
        public void OnActivated(UIApplication application)
        {
            SMDeviceInfos deviceInfos = SMDeviceInfos.DeviceInfosWithExternalId("123");
            SMManager.SharedInstance().SendDeviceInfo(deviceInfos);            
        }

        
        [Export("application:openURL:options:")]
        public bool OpenURL(UIApplication application, NSUrl url, NSDictionary options)
        {
            return true;
        }

        [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
        public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            SMManager.SharedInstance().WillPresentNotification(notification,completionHandler);
        }

        [Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            SMManager.SharedInstance().DidReceiveNotificationResponse(response,completionHandler);
        }

        [Export("anyMethodNameDidReceiveInAppMessage:")]
        void anyMethodNameDidReceiveInAppMessage(NSNotification notif)
        {
            Window = UIApplication.SharedApplication.KeyWindow;
            try
            {
                NSDictionary dict = (NSDictionary)notif.UserInfo;
                NSArray inAppData = (NSArray)dict.ObjectForKey(SelligentMobileiOS.Constants.kSMNotification_Data_InAppMessage);
                
                for (uint i = 0; i < inAppData.Count; i++)
                {
                    NSDictionary data = inAppData.GetItem<NSDictionary>(i);
                    SMManager.SharedInstance().DisplayNotificationID(data.ValueForKey(new NSString("id")).ToString());
                }
            }
            catch (Exception e)
            {
                var alertController = UIAlertController.Create("InAppMessage", "error trying to display in app message" + "\n" + e.Message + "\n" + e.StackTrace, UIAlertControllerStyle.Alert);
                //Add Action
                alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                // Present Alert
                Window.RootViewController.PresentViewController(alertController, true, null);

            }
        }

        [Export("anyMethodNameDidReceiveInAppContent:")]
        public void anyMethodNameDidReceiveInAppContent(NSNotification notif)
        {
                       
        }

        [Export("anyMethodNameButtonClicked:")]
        public void anyMethodNameButtonClicked(NSNotification notif)
        {
            NSDictionary dict = notif.UserInfo;
            SMNotificationButtonData btnData = (SMNotificationButtonData)dict.ObjectForKey(SelligentMobileiOS.Constants.kSMNotification_Data_ButtonData);
        }

        [Export("anyMethodNameDidReceiveRemoteNotification:")]
        public void anyMethodNameDidReceiveRemoteNotification(NSNotification notif)
        {
            NSDictionary dict = notif.UserInfo;
            NSDictionary notifData = (NSDictionary)dict.ObjectForKey(SelligentMobileiOS.Constants.kSMNotification_Data_RemoteNotification);
        }

        [Export("anyMethodNameWillDisplayNotification:")]
        public void anyMethodNameWillDisplayNotification(NSNotification notif)
        {
        }

        [Export("anyMethodNameWillDismissNotification:")]
        public void anyMethodNameWillDismissNotification(NSNotification notif)
        {
        }

        [Export("customAction:")]
        public void customAction(NSNotification notif)
        {
            Console.Write(@"customAction");
        }
    }
}

