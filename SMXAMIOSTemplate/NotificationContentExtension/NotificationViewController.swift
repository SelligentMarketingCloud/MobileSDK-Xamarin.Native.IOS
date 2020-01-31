//
//  NotificationViewController.swift
//  NotificationContentExtension
//
//  Created by Gilbert Schakal on 17/05/2018.
//  Copyright © 2018 Samy Ziat. All rights reserved.
//

import UIKit
import UserNotifications
import UserNotificationsUI

class NotificationViewController: UIViewController, UNNotificationContentExtension {

    @IBOutlet var label: UILabel?
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any required interface initialization here.
    }
    
    func didReceive(_ notification: UNNotification) {
        self.label?.text = notification.request.content.body
        
        let url = "URL"
        let clientID = "ClientID"
        let privateKey = "privateKey"
        
        //  Create the SMManagerSetting instance
        let setting: SMManagerSetting = SMManagerSetting(url: url, clientID: clientID, privateKey: privateKey)
        //Start sdk from extension
        SMManager.sharedInstance().startExtension(with: setting)
        
        //sdk api to add buttons from banner
        SMManager.sharedInstance().didReceive(notification)
    }

}
