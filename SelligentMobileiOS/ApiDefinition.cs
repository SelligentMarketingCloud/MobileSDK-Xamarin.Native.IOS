using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;


namespace SelligentMobileiOS
{
    // @interface SMBaseMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface SMBaseMessage
    {
        // @property (nonatomic) NSString * idMessage;
        [Export("idMessage")] string IdMessage { get; set; }

        // @property (nonatomic) NSDate * dateCreation;
        [Export("dateCreation", ArgumentSemantic.Assign)]
        NSDate DateCreation { get; set; }
    }

    //TODO VERIFY THIS
    // typedef void (^SMCompletionBlockSuccess)(int *);
    unsafe delegate void SMCompletionBlockSuccess(int arg0);

    //TODO VERIFY THIS
    // typedef void (^SMCompletionBlockFailure)(int *);
    unsafe delegate void SMCompletionBlockFailure(int arg0);

    // @interface SMDeviceInfos : NSObject
    [BaseType(typeof(NSObject))]
    interface SMDeviceInfos
    {
        // @property (nonatomic) NSString * externalId;
        [Export("externalId")] string ExternalId { get; set; }

        // +(instancetype)defaultDeviceInfos;
        [Static]
        [Export("defaultDeviceInfos")]
        SMDeviceInfos DefaultDeviceInfos();

        // +(instancetype)deviceInfosWithExternalId:(NSString *)externalId;
        [Static]
        [Export("deviceInfosWithExternalId:")]
        SMDeviceInfos DeviceInfosWithExternalId(string externalId);
    }

    // @interface SMMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface SMMessage
    {
        // @property (nonatomic, strong) NSString * messageSM;
        [Export("messageSM", ArgumentSemantic.Strong)]
        string MessageSM { get; set; }
    }

    // @interface SMFailure : SMMessage
    [BaseType(typeof(SMMessage))]
    interface SMFailure
    {
    }

    // @interface SMSuccess : SMMessage
    [BaseType(typeof(SMMessage))]
    interface SMSuccess
    {
    }

    // @interface SMEvent : NSObject
    [BaseType(typeof(NSObject))]
    interface SMEvent
    {
        // @property (nonatomic) BOOL shouldCache;
        [Export("shouldCache")] bool ShouldCache { get; set; }

        // +(instancetype _Nonnull)eventWithDictionary:(NSDictionary * _Nullable)dict;
        [Static]
        [Export("eventWithDictionary:")]
        SMEvent EventWithDictionary([NullAllowed] NSDictionary dict);

        // -(void)applyBlockSuccess:(SMCompletionBlockSuccess _Nullable)blockSuccess BlockFailure:(SMCompletionBlockFailure _Nullable)blockFailure;
        [Export("applyBlockSuccess:BlockFailure:")]
        void ApplyBlockSuccess([NullAllowed] SMCompletionBlockSuccess blockSuccess, [NullAllowed] SMCompletionBlockFailure blockFailure);
    }

    // @interface SMEventUser : SMEvent
    [BaseType(typeof(SMEvent))]
    interface SMEventUser
    {
    }

    // @interface SMEventUserLogin : SMEventUser
    [BaseType(typeof(SMEventUser))]
    interface SMEventUserLogin
    {
        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail;
        [Static]
        [Export("eventWithEmail:")]
        SMEventUserLogin EventWithEmail(string mail);

        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail Dictionary:(NSDictionary<NSString *,NSString *> * _Nullable)dict;
        [Static]
        [Export("eventWithEmail:Dictionary:")]
        SMEventUserLogin EventWithEmail(string mail, [NullAllowed] NSDictionary<NSString, NSString> dict);
    }

    // @interface SMEventUserLogout : SMEventUser
    [BaseType(typeof(SMEventUser))]
    interface SMEventUserLogout
    {
        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail;
        [Static]
        [Export("eventWithEmail:")]
        SMEventUserLogout EventWithEmail(string mail);

        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail Dictionary:(NSDictionary<NSString *,NSString *> * _Nullable)dict;
        [Static]
        [Export("eventWithEmail:Dictionary:")]
        SMEventUserLogout EventWithEmail(string mail, [NullAllowed] NSDictionary<NSString, NSString> dict);
    }

    // @interface SMEventUserRegistration : SMEventUser
    [BaseType(typeof(SMEventUser))]
    interface SMEventUserRegistration
    {
        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail;
        [Static]
        [Export("eventWithEmail:")]
        SMEventUserRegistration EventWithEmail(string mail);

        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail Dictionary:(NSDictionary<NSString *,NSString *> * _Nullable)dict;
        [Static]
        [Export("eventWithEmail:Dictionary:")]
        SMEventUserRegistration EventWithEmail(string mail, [NullAllowed] NSDictionary<NSString, NSString> dict);
    }

    // @interface SMEventUserUnregistration : SMEventUser
    [BaseType(typeof(SMEventUser))]
    interface SMEventUserUnregistration
    {
        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail;
        [Static]
        [Export("eventWithEmail:")]
        SMEventUserUnregistration EventWithEmail(string mail);

        // +(instancetype _Nonnull)eventWithEmail:(NSString * _Null_unspecified)mail Dictionary:(NSDictionary<NSString *,NSString *> * _Nullable)dict;
        [Static]
        [Export("eventWithEmail:Dictionary:")]
        SMEventUserUnregistration EventWithEmail(string mail, [NullAllowed] NSDictionary<NSString, NSString> dict);
    }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString * kSMNotification_Event_ButtonClicked;
        [Field("kSMNotification_Event_ButtonClicked", "__Internal")]
        NSString kSMNotification_Event_ButtonClicked { get; }

        // extern NSString * kSMNotification_Event_WillDisplayNotification;
        [Field("kSMNotification_Event_WillDisplayNotification", "__Internal")]
        NSString kSMNotification_Event_WillDisplayNotification { get; }

        // extern NSString * kSMNotification_Event_WillDismissNotification;
        [Field("kSMNotification_Event_WillDismissNotification", "__Internal")]
        NSString kSMNotification_Event_WillDismissNotification { get; }

        // extern NSString * kSMNotification_Event_DidReceiveRemoteNotification;
        [Field("kSMNotification_Event_DidReceiveRemoteNotification", "__Internal")]
        NSString kSMNotification_Event_DidReceiveRemoteNotification { get; }

        // extern NSString * kSMNotification_Event_DidReceiveInAppMessage;
        [Field("kSMNotification_Event_DidReceiveInAppMessage", "__Internal")]
        NSString kSMNotification_Event_DidReceiveInAppMessage { get; }

        // extern NSString * kSMNotification_Event_DidReceiveInAppContent;
        [Field("kSMNotification_Event_DidReceiveInAppContent", "__Internal")]
        NSString kSMNotification_Event_DidReceiveInAppContent { get; }

        // extern NSString * kSMNotification_Data_ButtonData;
        [Field("kSMNotification_Data_ButtonData", "__Internal")]
        NSString kSMNotification_Data_ButtonData { get; }

        // extern NSString * kSMNotification_Data_RemoteNotification;
        [Field("kSMNotification_Data_RemoteNotification", "__Internal")]
        NSString kSMNotification_Data_RemoteNotification { get; }

        // extern NSString * kSMNotification_Data_InAppMessage;
        [Field("kSMNotification_Data_InAppMessage", "__Internal")]
        NSString kSMNotification_Data_InAppMessage { get; }

        // extern NSString * kSMNotification_Data_InAppContent;
        [Field("kSMNotification_Data_InAppContent", "__Internal")]
        NSString kSMNotification_Data_InAppContent { get; }
    }

    // @interface SMLink : NSObject
    [BaseType(typeof(NSObject))]
    interface SMLink
    {
        // @property (nonatomic, strong) NSString * idButtonData;
        [Export("idButtonData", ArgumentSemantic.Strong)]
        string IdButtonData { get; set; }

        // @property (nonatomic, strong) NSString * label;
        [Export("label", ArgumentSemantic.Strong)]
        string Label { get; set; }

        // @property (nonatomic, strong) NSString * value;
        [Export("value", ArgumentSemantic.Strong)]
        string Value { get; set; }

        // @property (nonatomic) SMNotificationButtonType type;
        [Export("type", ArgumentSemantic.Assign)]
        SMNotificationButtonType Type { get; set; }
    }

    // @interface SMNotificationButtonData : SMLink
    [BaseType(typeof(SMLink))]
    public interface SMNotificationButtonData
    {
    }

    // @interface SMManagerSetting : NSObject
    [BaseType(typeof(NSObject))]
    public interface SMManagerSetting
    {
        // @property (nonatomic) BOOL shouldClearBadge;
        [Export("shouldClearBadge")]
        public bool ShouldClearBadge { get; set; }

        // @property (nonatomic) BOOL shouldDisplayRemoteNotification;
        [Export("shouldDisplayRemoteNotification")]
        public bool ShouldDisplayRemoteNotification { get; set; }

        // @property (nonatomic) SMClearCache clearCacheIntervalValue;
        [Export("clearCacheIntervalValue", ArgumentSemantic.Assign)]
        public SMClearCache ClearCacheIntervalValue { get; set; }

        // +(instancetype)settingWithUrl:(NSString *)urlName ClientID:(NSString *)clientID PrivateKey:(NSString *)privateKey;
        [Static]
        [Export("settingWithUrl:ClientID:PrivateKey:")]
        public SMManagerSetting SettingWithUrl(string urlName, string clientID, string privateKey);

        // -(void)configureInAppMessageServiceWithSetting:(SMManagerSettingIAM *)settingIAM;
        [Export("configureInAppMessageServiceWithSetting:")]
        public void ConfigureInAppMessageServiceWithSetting(SMManagerSettingIAM settingIAM);

        // -(void)configureInAppContentServiceWithSetting:(SMManagerSettingIAC *)settingIAC;
        [Export("configureInAppContentServiceWithSetting:")]
        public void ConfigureInAppContentServiceWithSetting(SMManagerSettingIAC settingIAC);

        // -(void)configureLocationService;
        [Export("configureLocationService")]
        public void ConfigureLocationService();
    }

    // @interface SMManagerSettingIAM : NSObject
    [BaseType(typeof(NSObject))]
    public interface SMManagerSettingIAM
    {
        // +(instancetype)settingWithBackgroundFetchOnly;
        [Static]
        [Export("settingWithBackgroundFetchOnly")]
        public SMManagerSettingIAM SettingWithBackgroundFetchOnly();

        // +(instancetype)settingWithRefreshType:(SMInAppRefreshType)refreshType;
        [Static]
        [Export("settingWithRefreshType:")]
        public SMManagerSettingIAM SettingWithRefreshType(SMInAppRefreshType refreshType);

        // +(instancetype)settingWithRefreshType:(SMInAppRefreshType)refreshType ShouldPerformBackgroundFetch:(BOOL)shouldPerformBackgroundFetch;
        [Static]
        [Export("settingWithRefreshType:ShouldPerformBackgroundFetch:")]
        public SMManagerSettingIAM SettingWithRefreshType(SMInAppRefreshType refreshType, bool shouldPerformBackgroundFetch);
    }

    // @interface SMManagerSettingIAC : NSObject
    [BaseType(typeof(NSObject))]
    public interface SMManagerSettingIAC
    {
        // +(instancetype)settingWithBackgroundFetchOnly;
        [Static]
        [Export("settingWithBackgroundFetchOnly")]
        public SMManagerSettingIAC SettingWithBackgroundFetchOnly();

        // +(instancetype)settingWithRefreshType:(SMInAppRefreshType)refreshType;
        [Static]
        [Export("settingWithRefreshType:")]
        public SMManagerSettingIAC SettingWithRefreshType(SMInAppRefreshType refreshType);

        // +(instancetype)settingWithRefreshType:(SMInAppRefreshType)refreshType ShouldPerformBackgroundFetch:(BOOL)shouldPerformBackgroundFetch;
        [Static]
        [Export("settingWithRefreshType:ShouldPerformBackgroundFetch:")]
        public SMManagerSettingIAC SettingWithRefreshType(SMInAppRefreshType refreshType, bool shouldPerformBackgroundFetch);
    }

    // @interface SMManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SMManager
    {
        // @property (nonatomic) NSString * _Nonnull versionLib;
        [Export("versionLib")] string VersionLib { get; set; }

        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        SMManager SharedInstance();

        // -(void)startWithLaunchOptions:(NSDictionary * _Nullable)launchOptions Setting:(SMManagerSetting * _Null_unspecified)setting;
        [Export("startWithLaunchOptions:Setting:")]
        void StartWithLaunchOptions([NullAllowed] NSDictionary launchOptions, SMManagerSetting setting);

        // -(void)reloadSetting:(SMManagerSetting * _Null_unspecified)setting;
        [Export("reloadSetting:")]
        void ReloadSetting(SMManagerSetting setting);
    }

    // @interface DataTransaction (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_DataTransaction
    {
        // -(void)sendDeviceInfo __attribute__((deprecated("")));
        [Export("sendDeviceInfo")]
        void SendDeviceInfo();

        // -(void)sendDeviceInfo:(SMDeviceInfos *)deviceInfos;
        [Export("sendDeviceInfo:")]
        void SendDeviceInfo(SMDeviceInfos deviceInfos);
    }

    // @interface RemoteNotification (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_RemoteNotification
    {
        // -(void)registerForRemoteNotification;
        [Export("registerForRemoteNotification")]
        void RegisterForRemoteNotification();

        // -(void)unregisterForRemoteNotification __attribute__((deprecated(""))) __attribute__((deprecated("Use disableRemoteNotification instead.")));
        [Export("unregisterForRemoteNotification")]
        void UnregisterForRemoteNotification();

        // -(void)enableRemoteNotification;
        [Export("enableRemoteNotification")]
        void EnableRemoteNotification();

        // -(void)disableRemoteNotification;
        [Export("disableRemoteNotification")]
        void DisableRemoteNotification();

        // -(void)didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken;
        [Export("didRegisterForRemoteNotificationsWithDeviceToken:")]
        void DidRegisterForRemoteNotificationsWithDeviceToken(NSData deviceToken);

        // -(void)didRegisterUserNotificationSettings:(UIUserNotificationSettings *)notificationSettings __attribute__((deprecated("")));
        [Export("didRegisterUserNotificationSettings:")]
        void DidRegisterUserNotificationSettings(UIUserNotificationSettings notificationSettings);

        // -(void)didRegisterUserNotificationSettings;
        [Export("didRegisterUserNotificationSettings")]
        void DidRegisterUserNotificationSettings();

        // -(void)didFailToRegisterForRemoteNotificationsWithError:(NSError *)error;
        [Export("didFailToRegisterForRemoteNotificationsWithError:")]
        void DidFailToRegisterForRemoteNotificationsWithError(NSError error);

        // -(void)didReceiveRemoteNotification:(NSDictionary *)userInfo;
        [Export("didReceiveRemoteNotification:")]
        void DidReceiveRemoteNotification(NSDictionary userInfo);

        // -(void)displayNotificationID:(NSString *)idNotification;
        [Export("displayNotificationID:")]
        void DisplayNotificationID(string idNotification);

        // -(void)displayLastReceivedRemotePushNotification;
        [Export("displayLastReceivedRemotePushNotification")]
        void DisplayLastReceivedRemotePushNotification();

        // -(NSDictionary *)retrieveLastRemotePushNotification;
        [Export("retrieveLastRemotePushNotification")]
        NSDictionary RetrieveLastRemotePushNotification();
    }

    // @interface UserNotification (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_UserNotification
    {
        // -(void)didReceiveNotificationResponse:(UNNotificationResponse * _Nonnull)response;
        [Export("didReceiveNotificationResponse:")]
        void DidReceiveNotificationResponse(UNNotificationResponse response);

        // -(void)didReceiveNotificationResponse:(UNNotificationResponse * _Nonnull)response withCompletionHandler:(void (^ _Nullable)(void))completionHandler;
        [Export("didReceiveNotificationResponse:withCompletionHandler:")]
        void DidReceiveNotificationResponse(UNNotificationResponse response, [NullAllowed] Action completionHandler);

        // -(void)willPresentNotification:(UNNotification * _Nonnull)notification;
        [Export("willPresentNotification:")]
        void WillPresentNotification(UNNotification notification);

        // -(void)willPresentNotification:(UNNotification * _Nonnull)notification withCompletionHandler:(void (^ _Nullable)(UNNotificationPresentationOptions))completionHandler;
        [Export("willPresentNotification:withCompletionHandler:")]
        void WillPresentNotification(UNNotification notification,
            [NullAllowed] Action<UNNotificationPresentationOptions> completionHandler);

        // -(void)startExtensionWithSetting:(SMManagerSetting * _Nonnull)setting;
        [Export("startExtensionWithSetting:")]
        void StartExtensionWithSetting(SMManagerSetting setting);

        // -(void)didReceiveNotification:(UNNotification * _Nonnull)notification;
        [Export("didReceiveNotification:")]
        void DidReceiveNotification(UNNotification notification);

        // -(UNMutableNotificationContent * _Nullable)didReceiveNotificationRequest:(UNNotificationRequest * _Nonnull)request;
        [Export("didReceiveNotificationRequest:")]
        [return: NullAllowed]
        UNMutableNotificationContent DidReceiveNotificationRequest(UNNotificationRequest request);

        // -(void)didReceiveNotificationRequest:(UNNotificationRequest * _Nonnull)request withContentHandler:(void (^ _Nullable)(UNNotificationContent * _Nonnull))contentHandler;
        [Export("didReceiveNotificationRequest:withContentHandler:")]
        void DidReceiveNotificationRequest(UNNotificationRequest request, [NullAllowed] Action<UNNotificationContent> contentHandler);

        // -(void)serviceExtensionTimeWillExpire;
        [Export("serviceExtensionTimeWillExpire")]
        void ServiceExtensionTimeWillExpire();
    }

    // @interface InAppMessage (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_InAppMessage
    {
        // -(void)enableInAppMessage:(BOOL)shouldEnable;
        [Export("enableInAppMessage:")]
        void EnableInAppMessage(bool shouldEnable);

        // -(void)performIAMFetchWithCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler;
        [Export("performIAMFetchWithCompletionHandler:")]
        void PerformIAMFetchWithCompletionHandler(Action<UIBackgroundFetchResult> completionHandler);
    }

    // @interface SMInAppContentMessage : SMBaseMessage
    [BaseType(typeof(SMBaseMessage))]
    interface SMInAppContentMessage
    {
        // @property (nonatomic) NSString * title;
        [Export("title")] string Title { get; set; }

        // @property (nonatomic) NSString * body;
        [Export("body")] string Body { get; set; }

        // @property (nonatomic) NSString * category;
        [Export("category")] string Category { get; set; }

        // @property (nonatomic) SMInAppContentType iacType;
        [Export("iacType", ArgumentSemantic.Assign)]
        SMInAppContentType IacType { get; set; }

        // @property (nonatomic) NSDate * contentExpiration;
        [Export("contentExpiration", ArgumentSemantic.Assign)]
        NSDate ContentExpiration { get; set; }

        // @property (nonatomic) NSArray * arrayIACLinks;
        [Export("arrayIACLinks", ArgumentSemantic.Assign)]
        SMLink[] ArrayIACLinks { get; set; }
    }

    // @interface InAppContent (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_InAppContent
    {
        // -(void)showSMController:(SMInAppContentViewController *)smViewController InContainerView:(UIView *)containerView OfParentViewController:(UIViewController *)parentViewController;
        [Export("showSMController:InContainerView:OfParentViewController:")]
        void ShowSMController(SMInAppContentViewController smViewController, UIView containerView, UIViewController parentViewController);

        // -(NSArray *)getInAppContentsForCategory:(NSString *)category Type:(SMInAppContentType)type;
        [Export("getInAppContentsForCategory:Type:")]
        SMInAppContentMessage[] GetInAppContentsForCategory(string category, SMInAppContentType type);

        // -(NSArray *)getInAppContentsForCategory:(NSString *)category Type:(SMInAppContentType)type Max:(int)max;
        [Export("getInAppContentsForCategory:Type:Max:")]
        SMInAppContentMessage[] GetInAppContentsForCategory(string category, SMInAppContentType type, int max);

        // -(void)setInAppContentAsSeen:(SMInAppContentMessage *)inAppContent;
        [Export("setInAppContentAsSeen:")]
        void SetInAppContentAsSeen(SMInAppContentMessage inAppContent);

        // -(void)executeLinkAction:(SMLink *)link InAppContent:(SMInAppContentMessage *)inAppContent;
        [Export("executeLinkAction:InAppContent:")]
        void ExecuteLinkAction(SMLink link, SMInAppContentMessage inAppContent);

        // -(void)performIACFetchWithCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler;
        [Export("performIACFetchWithCompletionHandler:")]
        void PerformIACFetchWithCompletionHandler(Action<UIBackgroundFetchResult> completionHandler);
    }

    // @interface SilentPush (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_SilentPush
    {
        // -(void)didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler;
        [Export("didReceiveRemoteNotification:fetchCompletionHandler:")]
        void DidReceiveRemoteNotification(NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler);

        // -(void)didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler ForceResultFetch:(UIBackgroundFetchResult)resultFetch;
        [Export("didReceiveRemoteNotification:fetchCompletionHandler:ForceResultFetch:")]
        void DidReceiveRemoteNotification(NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler,
            UIBackgroundFetchResult resultFetch);
    }

    // @interface SMEvent (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_SMEvent
    {
        // -(void)sendSMEvent:(SMEvent *)event;
        [Export("sendSMEvent:")]
        void SendSMEvent(SMEvent @event);
    }

    // @interface Log (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_Log
    {
        // -(void)applyLogLevel:(SMLogLevel)logLevel;
        [Export("applyLogLevel:")]
        void ApplyLogLevel(SMLogLevel logLevel);
    }

    // @interface Location (SMManager)
    
    [BaseType(typeof(SMManager))]
    [Protocol]
    public interface SMManager_Location
    {
        // -(SMLocationAuthorisationStatus)currentAuthorisationStatus;
        [Export("currentAuthorisationStatus")]
        public  SMLocationAuthorisationStatus CurrentAuthorisationStatus { get; }

        // -(void)requestLocationAuthorisation:(SMLocationAuthorisationType)type;
        [Export("requestLocationAuthorisation:")]
        public void RequestLocationAuthorisation(SMLocationAuthorisationType type);

        // -(void)enableGeoLocation;
        [Export("enableGeoLocation")]
        public void EnableGeoLocation();

        // -(void)disableGeoLocation;
        [Export("disableGeoLocation")]
        public void DisableGeoLocation();

        // -(BOOL)isGeoLocationEnabled;
        [Export("isGeoLocationEnabled")]
        public bool IsGeoLocationEnabled { get; }
    }

    // @interface StyleOptions (SMManager)
    [Category]
    [BaseType(typeof(SMManager))]
    interface SMManager_StyleOptions
    {
        // -(void)loadStyleOptions:(SMInAppContentStyleOptions *)options;
        [Export("loadStyleOptions:")]
        void LoadStyleOptions(SMInAppContentStyleOptions options);

        // -(void)resetStyleOptions;
        [Export("resetStyleOptions")]
        void ResetStyleOptions();
    }

    // @interface SMInAppContentStyleOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface SMInAppContentStyleOptions
    {
        // @property (nonatomic) _Bool mainViewIsScrollable;
        [Export("mainViewIsScrollable")] bool MainViewIsScrollable { get; set; }

        // @property (nonatomic) UIColor * mainViewBackgroundColor;
        [Export("mainViewBackgroundColor", ArgumentSemantic.Assign)]
        UIColor MainViewBackgroundColor { get; set; }

        // @property (nonatomic) UIActivityIndicatorViewStyle activityIndicatorStyle;
        [Export("activityIndicatorStyle", ArgumentSemantic.Assign)]
        UIActivityIndicatorViewStyle ActivityIndicatorStyle { get; set; }

        // @property (nonatomic) _Bool isStatusBarHidden;
        [Export("isStatusBarHidden")] bool IsStatusBarHidden { get; set; }

        // @property (nonatomic) CGFloat boxLeading;
        [Export("boxLeading")] nfloat BoxLeading { get; set; }

        // @property (nonatomic) CGFloat boxTrailing;
        [Export("boxTrailing")] nfloat BoxTrailing { get; set; }

        // @property (nonatomic) CGFloat marginBetweenBoxes;
        [Export("marginBetweenBoxes")] nfloat MarginBetweenBoxes { get; set; }

        // @property (nonatomic) CGFloat marginBetweenFirstBoxAndTopOfView;
        [Export("marginBetweenFirstBoxAndTopOfView")]
        nfloat MarginBetweenFirstBoxAndTopOfView { get; set; }

        // @property (nonatomic) CGFloat marginBetweenLastBoxAndBottomOfView;
        [Export("marginBetweenLastBoxAndBottomOfView")]
        nfloat MarginBetweenLastBoxAndBottomOfView { get; set; }

        // @property (nonatomic) CGFloat boxBorderWidth;
        [Export("boxBorderWidth")] nfloat BoxBorderWidth { get; set; }

        // @property (nonatomic) UIColor * boxBorderColor;
        [Export("boxBorderColor", ArgumentSemantic.Assign)]
        UIColor BoxBorderColor { get; set; }

        // @property (nonatomic) CGFloat boxCornerRadius;
        [Export("boxCornerRadius")] nfloat BoxCornerRadius { get; set; }

        // @property (nonatomic) UIColor * boxBackgroundColor;
        [Export("boxBackgroundColor", ArgumentSemantic.Assign)]
        UIColor BoxBackgroundColor { get; set; }

        // @property (nonatomic) UIColor * boxShadowColor;
        [Export("boxShadowColor", ArgumentSemantic.Assign)]
        UIColor BoxShadowColor { get; set; }

        // @property (nonatomic) CGFloat boxShadowOpacity;
        [Export("boxShadowOpacity")] nfloat BoxShadowOpacity { get; set; }

        // @property (nonatomic) CGFloat boxShadowRadius;
        [Export("boxShadowRadius")] nfloat BoxShadowRadius { get; set; }

        // @property (nonatomic) CGSize boxShadowOffset;
        [Export("boxShadowOffset", ArgumentSemantic.Assign)]
        CGSize BoxShadowOffset { get; set; }

        // @property (nonatomic) CGFloat titleBorderWidth;
        [Export("titleBorderWidth")] nfloat TitleBorderWidth { get; set; }

        // @property (nonatomic) UIColor * titleBorderColor;
        [Export("titleBorderColor", ArgumentSemantic.Assign)]
        UIColor TitleBorderColor { get; set; }

        // @property (nonatomic) CGFloat titleCornerRadius;
        [Export("titleCornerRadius")] nfloat TitleCornerRadius { get; set; }

        // @property (nonatomic) UIColor * titleBackgroundColor;
        [Export("titleBackgroundColor", ArgumentSemantic.Assign)]
        UIColor TitleBackgroundColor { get; set; }

        // @property (nonatomic) CGFloat titleNumberOfLines;
        [Export("titleNumberOfLines")] nfloat TitleNumberOfLines { get; set; }

        //TODO : VERIFY THIS.

        /*
        // @property (nonatomic) NSLineBreakMode titleLineBreakMode;
        [Export("titleLineBreakMode", ArgumentSemantic.Assign)]
        NSLineBreakMode TitleLineBreakMode { get; set; }

        // @property (nonatomic) NSTextAlignment titleTextAlignment;
        [Export("titleTextAlignment", ArgumentSemantic.Assign)]
        NSTextAlignment TitleTextAlignment { get; set; }
        */


        // @property (nonatomic) NSDictionary * titleAttributes;
        [Export("titleAttributes", ArgumentSemantic.Assign)]
        NSDictionary TitleAttributes { get; set; }

        // @property (nonatomic) UIColor * titleTextColor;
        [Export("titleTextColor", ArgumentSemantic.Assign)]
        UIColor TitleTextColor { get; set; }

        // @property (nonatomic) UIFont * titleFont;
        [Export("titleFont", ArgumentSemantic.Assign)]
        UIFont TitleFont { get; set; }

        // @property (nonatomic) CGFloat titleTrailing;
        [Export("titleTrailing")] nfloat TitleTrailing { get; set; }

        // @property (nonatomic) CGFloat titleLeading;
        [Export("titleLeading")] nfloat TitleLeading { get; set; }

        // @property (nonatomic) CGFloat titleTop;
        [Export("titleTop")] nfloat TitleTop { get; set; }

        // @property (nonatomic) UIColor * titleShadowColor;
        [Export("titleShadowColor", ArgumentSemantic.Assign)]
        UIColor TitleShadowColor { get; set; }

        // @property (nonatomic) CGFloat titleShadowOpacity;
        [Export("titleShadowOpacity")] nfloat TitleShadowOpacity { get; set; }

        // @property (nonatomic) CGFloat titleShadowRadius;
        [Export("titleShadowRadius")] nfloat TitleShadowRadius { get; set; }

        // @property (nonatomic) CGSize titleShadowOffset;
        [Export("titleShadowOffset", ArgumentSemantic.Assign)]
        CGSize TitleShadowOffset { get; set; }

        // @property (nonatomic) _Bool showTitleBorderBottom;
        [Export("showTitleBorderBottom")] bool ShowTitleBorderBottom { get; set; }

        // @property (nonatomic) UIColor * titleBorderBottomColor;
        [Export("titleBorderBottomColor", ArgumentSemantic.Assign)]
        UIColor TitleBorderBottomColor { get; set; }

        // @property (nonatomic) CGFloat textViewTrailing;
        [Export("textViewTrailing")] nfloat TextViewTrailing { get; set; }

        // @property (nonatomic) CGFloat textViewLeading;
        [Export("textViewLeading")] nfloat TextViewLeading { get; set; }

        // @property (nonatomic) CGFloat textViewTop;
        [Export("textViewTop")] nfloat TextViewTop { get; set; }

        // @property (nonatomic) CGPoint textViewContentOffset;
        [Export("textViewContentOffset", ArgumentSemantic.Assign)]
        CGPoint TextViewContentOffset { get; set; }

        // @property (nonatomic) UIEdgeInsets textViewContentInset;
        [Export("textViewContentInset", ArgumentSemantic.Assign)]
        UIEdgeInsets TextViewContentInset { get; set; }

        // @property (nonatomic) CGFloat textViewBorderWidth;
        [Export("textViewBorderWidth")] nfloat TextViewBorderWidth { get; set; }

        // @property (nonatomic) UIColor * textViewBorderColor;
        [Export("textViewBorderColor", ArgumentSemantic.Assign)]
        UIColor TextViewBorderColor { get; set; }

        // @property (nonatomic) CGFloat textViewCornerRadius;
        [Export("textViewCornerRadius")] nfloat TextViewCornerRadius { get; set; }

        // @property (nonatomic) UIColor * textViewBackgroundColor;
        [Export("textViewBackgroundColor", ArgumentSemantic.Assign)]
        UIColor TextViewBackgroundColor { get; set; }

        // @property (nonatomic) SMContentAlignment linksAlignment;
        [Export("linksAlignment", ArgumentSemantic.Assign)]
        SMContentAlignment LinksAlignment { get; set; }

        // @property (nonatomic) CGFloat linksMargin;
        [Export("linksMargin")] nfloat LinksMargin { get; set; }

        // @property (nonatomic) CGFloat linksTop;
        [Export("linksTop")] nfloat LinksTop { get; set; }

        // @property (nonatomic) CGFloat linksBottom;
        [Export("linksBottom")] nfloat LinksBottom { get; set; }

        // @property (nonatomic) CGFloat marginBetweenLinks;
        [Export("marginBetweenLinks")] nfloat MarginBetweenLinks { get; set; }

        // @property (nonatomic) CGFloat linkBorderWidth;
        [Export("linkBorderWidth")] nfloat LinkBorderWidth { get; set; }

        // @property (nonatomic) UIColor * linkBorderColor;
        [Export("linkBorderColor", ArgumentSemantic.Assign)]
        UIColor LinkBorderColor { get; set; }

        // @property (nonatomic) CGFloat linkCornerRadius;
        [Export("linkCornerRadius")] nfloat LinkCornerRadius { get; set; }

        // @property (nonatomic) UIColor * linkShadowColor;
        [Export("linkShadowColor", ArgumentSemantic.Assign)]
        UIColor LinkShadowColor { get; set; }

        // @property (nonatomic) CGFloat linkShadowOpacity;
        [Export("linkShadowOpacity")] nfloat LinkShadowOpacity { get; set; }

        // @property (nonatomic) CGFloat linkShadowRadius;
        [Export("linkShadowRadius")] nfloat LinkShadowRadius { get; set; }

        // @property (nonatomic) CGSize linkShadowOffset;
        [Export("linkShadowOffset", ArgumentSemantic.Assign)]
        CGSize LinkShadowOffset { get; set; }

        // @property (nonatomic) UIColor * linkBackgroundColor;
        [Export("linkBackgroundColor", ArgumentSemantic.Assign)]
        UIColor LinkBackgroundColor { get; set; }

        // @property (nonatomic) UIColor * linkTextColor;
        [Export("linkTextColor", ArgumentSemantic.Assign)]
        UIColor LinkTextColor { get; set; }

        // @property (nonatomic) UIFont * linkFont;
        [Export("linkFont", ArgumentSemantic.Assign)]
        UIFont LinkFont { get; set; }

        // @property (nonatomic) UIEdgeInsets linkContentEdgeInsets;
        [Export("linkContentEdgeInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets LinkContentEdgeInsets { get; set; }

        // +(instancetype)defaultStylingOptions;
        [Static]
        [Export("defaultStylingOptions")]
        SMInAppContentStyleOptions DefaultStylingOptions();
    }

    // @interface SMInAppContentViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface SMInAppContentViewController
    {
        // @property (nonatomic, strong) NSString * category;
        [Export("category", ArgumentSemantic.Strong)]
        string Category { get; set; }

        // @property (nonatomic) _Bool isEmpty;
        [Export("isEmpty")] bool IsEmpty { get; set; }
    }

    // @interface SMInAppContentImageViewController : SMInAppContentViewController
    [BaseType(typeof(SMInAppContentViewController))]
    interface SMInAppContentImageViewController
    {
        // +(instancetype)viewControllerForCategory:(NSString *)category;
        [Static]
        [Export("viewControllerForCategory:")]
        SMInAppContentImageViewController ViewControllerForCategory(string category);

        // +(instancetype)viewControllerForCategory:(NSString *)category AndOptions:(SMInAppContentStyleOptions *)options;
        [Static]
        [Export("viewControllerForCategory:AndOptions:")]
        SMInAppContentImageViewController ViewControllerForCategory(string category, SMInAppContentStyleOptions options);
    }

    // @interface SMInAppContentURLViewController : SMInAppContentViewController
    [BaseType(typeof(SMInAppContentViewController))]
    interface SMInAppContentURLViewController
    {
        // +(instancetype)viewControllerForCategory:(NSString *)category;
        [Static]
        [Export("viewControllerForCategory:")]
        SMInAppContentURLViewController ViewControllerForCategory(string category);

        // +(instancetype)viewControllerForCategory:(NSString *)category AndOptions:(SMInAppContentStyleOptions *)options;
        [Static]
        [Export("viewControllerForCategory:AndOptions:")]
        SMInAppContentURLViewController ViewControllerForCategory(string category, SMInAppContentStyleOptions options);
    }

    // @interface SMInAppContentHTMLViewController : SMInAppContentViewController
    [BaseType(typeof(SMInAppContentViewController))]
    interface SMInAppContentHTMLViewController
    {
        // +(instancetype)viewControllerForCategory:(NSString *)category;
        [Static]
        [Export("viewControllerForCategory:")]
        SMInAppContentHTMLViewController ViewControllerForCategory(string category);

        // +(instancetype)viewControllerForCategory:(NSString *)category AndOptions:(SMInAppContentStyleOptions *)options;
        [Static]
        [Export("viewControllerForCategory:AndOptions:")]
        SMInAppContentHTMLViewController ViewControllerForCategory(string category, SMInAppContentStyleOptions options);

        // +(instancetype)viewControllerForCategory:(NSString *)category InNumberOfBoxes:(int)numberofboxes;
        [Static]
        [Export("viewControllerForCategory:InNumberOfBoxes:")]
        SMInAppContentHTMLViewController ViewControllerForCategory(string category, int numberofboxes);

        // +(instancetype)viewControllerForCategory:(NSString *)category InNumberOfBoxes:(int)numberofboxes AndOptions:(SMInAppContentStyleOptions *)options;
        [Static]
        [Export("viewControllerForCategory:InNumberOfBoxes:AndOptions:")]
        SMInAppContentHTMLViewController ViewControllerForCategory(string category, int numberofboxes, SMInAppContentStyleOptions options);
    }
}