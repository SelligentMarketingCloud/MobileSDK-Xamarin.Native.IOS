using Foundation;
using SelligentMobileiOS;
using System;
using UIKit;

namespace testApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            SetupUI();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void RefreshIACControllers()
        {
            SMInAppContentURLViewController urlMainVc = SMInAppContentURLViewController.ViewControllerForCategory("MAIN");
            if(!urlMainVc.IsEmpty)
            {
                urlMainVc.ReloadInputViews();
            }            
        }

        public void SetupUI()
        {
            //initialize with your styling options
            SMInAppContentStyleOptions options = getIACStyleOptions();
            //get the sdk SMInAppContentHTMLViewController
            SMInAppContentURLViewController urlVC = SMInAppContentURLViewController.ViewControllerForCategory("MAIN");
            //Check if IAC are available for this type and category
            if (!urlVC.IsEmpty)
            {
                //display SMInAppContentHTMLViewController in your containerView
                SMManager.SharedInstance().ShowSMController(urlVC, containerView, this);
            }
        }

        SMInAppContentStyleOptions getIACStyleOptions()
        {
            UIColor greenColor = UIColor.FromRGBA(58 / 255, 190 / 255, 190 / 255, 1);
            UIColor backgroundColor = UIColor.FromRGBA(250 / 255, 250 / 255, 250 / 255, 1 / 2);

            //call to SMInAppContentStyleOptions constructor
            SMInAppContentStyleOptions smOptions = SMInAppContentStyleOptions.DefaultStylingOptions();

            //set the properties you need to customise visual aspect of html boxes
            smOptions.MarginBetweenFirstBoxAndTopOfView = 0;
            smOptions.TitleTop = 10;
            smOptions.TitleTextColor = greenColor;
            smOptions.ShowTitleBorderBottom = true;
            smOptions.TitleBorderBottomColor = UIColor.FromRGBA(205 / 255, 205 / 255, 205 / 255, 8 / 10);
            smOptions.TitleBackgroundColor = backgroundColor;
            smOptions.LinkBackgroundColor = greenColor;
            smOptions.LinkTextColor = UIColor.White;
            smOptions.LinksAlignment = SMContentAlignment.Right;
            smOptions.LinksMargin = 20;
            smOptions.LinkContentEdgeInsets = new UIEdgeInsets(6.0f, 6.0f, 6.0f, 6.0f);
            smOptions.BoxBackgroundColor = backgroundColor;
            smOptions.BoxBorderWidth = 0.0f;
            smOptions.MainViewBackgroundColor = UIColor.White;
            smOptions.TextViewBackgroundColor = backgroundColor;

            return smOptions;

        }

        partial void buttonSendEventPressed(UIButton sender)
        {
            //  We create a custom-event
            //  Some basic events are already created for you. Please check SMHelper.h
            NSDictionary dict = new NSDictionary<NSString,NSString>(new NSString("key"), new NSString("value"));            
            SMEvent eventCustom = SMEvent.EventWithDictionary(dict);
            SMManager.SharedInstance().SendSMEvent(eventCustom);
        }
    }
}