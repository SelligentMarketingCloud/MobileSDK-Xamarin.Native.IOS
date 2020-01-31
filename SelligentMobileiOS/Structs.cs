using System;
using ObjCRuntime;

namespace SelligentMobileiOS
{
	[Native]
	public enum SMClearCache : long
	{
		Auto,
		None,
		Week,
		Month,
		Quarter
	}

	[Native]
	public enum SMContentAlignment : long
	{
		Left,
		Right,
		Center
	}

	[Native]
	public enum SMDisplayMode : long
	{
		Unknown = -1,
		OnlyOnce = 0,
		UntilReplaced = 1
	}

	[Native]
	public enum SMNotificationButtonType : long
	{
		Unknown = -1,
		Simple = 0,
		OpenPhoneCall = 1,
		OpenSms = 2,
		OpenMail = 3,
		OpenBrowser = 4,
		OpenApplication = 5,
		RateApplication = 6,
		CustomActionBroadcastEvent = 7,
		Return_Text = 8,
		Return_Photo = 9,
		Return_TextAndPhoto = 10,
		Passbook = 11,
		DeepLink = 13
	}

	[Native]
	public enum SMInAppRefreshType : long
	{
		None,
		Minutely,
		Hourly,
		Daily
	}

	[Flags]
	[Native]
	public enum SMInAppContentType : long
	{
		Unknown = -0x2,
		Html = 0x1,
		Url = 0x2,
		Image = 0x3
	}

	[Flags]
	[Native]
	public enum SMLogLevel : long
	{
		None = 0x0,
		Info = 1L << 1,
		Warning = 1L << 2,
		Error = 1L << 3,
		HTTPCall = 1L << 4,
		Location = 1L << 5,
		All = 0xff
	}

	[Native]
	public enum SMLocationAuthorisationType : long
	{
		InUse,
		Always
	}

	[Native]
	public enum SMLocationAuthorisationStatus : long
	{
		Unknown,
		Refused,
		GrantedInUse,
		GrantedAlways
	}

}
