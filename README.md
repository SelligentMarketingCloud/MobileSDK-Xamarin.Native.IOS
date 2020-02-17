# MobileSDK-Xamarin

## 1. Installation

There are two ways you can use the Selligent Xamarin iOS binding library:

1.	Direct reference to the dll :

	1.	Download the *SelligentMobile_iOS_Xamarin.dll*  dll into your solution folder
	1.	Right click on the "References" folder in your solution and select "Add References..."
	1.	In the windows that appears select ".Net Assemblies" tab at the top of the window
	1.	Click "Browse..." at the bottom right of the pane
	1.	Find and select the *SelligentMobile_iOS_Xamarin.dll* and click "open"

1.	Reference the binding library project :

	1.	Pull the repository into your solution folder
	1.	Right click on the solution in your IDE and select "Add" -> "Existing Project..."
	1.	Open the folder named *SelligentMobileiOS* containing the binding library and double click the "SelligentMobileiOS.csproj" file.
	1.	Right click on the "References" folder in your solution and select "Add References..."
	1.	In the windows that appears select "Projects" tab at the top of the window
	1.	Select the checkbox next to the binding library project you just added and click "Ok"
	1.	Build the SelligentMobileiOS project

After following one of these set of steps the *SelligentMobile_iOS_Xamarin.dll* will be added to your solution and you can start using it in your code by using "Com.Selligent.Sdk"
(IntelliSense errors about not recognizing "SelligentMobileiOS" are fixed by referencing the DLL instead of the binding project)

## 2. Documentation

You can refer to the native documentation for information on how to use the SDK. The documentation is availble at the following link : [iOS - Using the SDK](https://github.com/SelligentMarketingCloud/MobileSDK-iOS/blob/master/Documentation/Using%20the%20SDK.pdf)

You can also take a look at the sample app provided under the SMXAMiOSTemplate folder
