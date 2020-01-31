//
//  NotificationService.swift
//  NotificationServiceExtension
//
//  Created by Thibaut Colin on 27/07/2018.
//  Copyright © 2018 Samy Ziat. All rights reserved.
//

import UserNotifications

class NotificationService: UNNotificationServiceExtension {

    //var contentHandler: ((UNNotificationContent) -> Void)?
    //var bestAttemptContent: UNMutableNotificationContent?

    override func didReceive(_ request: UNNotificationRequest, withContentHandler contentHandler: @escaping (UNNotificationContent) -> Void) {
       // self.contentHandler = contentHandler
       // bestAttemptContent = (request.content.mutableCopy() as? UNMutableNotificationContent)
        
        // Init and start the sdk.
        let url = "URL"
        let clientID = "ClientID"
        let privateKey = "privateKey"
        
        //  Create the SMManagerSetting instance
        let setting: SMManagerSetting = SMManagerSetting(url: url, clientID: clientID, privateKey: privateKey)
        
        //Start sdk from extension
        SMManager.sharedInstance().startExtension(with: setting)
        
        //FROM HERE YOU WILL HAVE TO CHOOSE THE POSSIBLE IMPLEMENTATION THAT CORRESPOND BETTER TO YOUR NEEDS
        
        // FIRST implementation - manage the call to the block, which is executed with the modified notification content.
            //Provide the request with the original notification content to the sdk and return the updated notification content
         //  bestAttemptContent = SMManager.sharedInstance().didReceive(request)
        
            //call the completion handler when done.
            //contentHandler(bestAttemptContent!)
        
        // SECOND implementation - let the library manage this for you.
            //Provide the request with the original notification content to the sdk and the contentHandler.
        SMManager.sharedInstance().didReceive(request, withContentHandler: contentHandler)
    }
    
    // Return something before time expires.
    override func serviceExtensionTimeWillExpire() {
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
            SMManager.sharedInstance().serviceExtensionTimeWillExpire();
    }
}
