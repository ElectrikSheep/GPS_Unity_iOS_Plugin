//
//  LCT_GeoLocation.h
//  Geo_LocatioPlugin
//
//  Created by L on 2/5/2014.
//  Copyright (c) 2014 ElectrikSheep. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreLocation/CoreLocation.h>


@interface LCT_GeoLocation : NSObject <CLLocationManagerDelegate>

@property (strong, nonatomic) CLLocationManager *lm ;


// The singleton created to start listening to device
+(LCT_GeoLocation*)sharedInstance ;

-(void) startRecording_Location ;

@end
