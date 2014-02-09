//
//  LCT_GeoLocation.h
//  Geo_LocatioPlugin
//
//  Created by L on 2/5/2014.
//  Copyright (c) 2014 ElectrikSheep. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreLocation/CoreLocation.h>

typedef void (*callbackFunc)(double, double);
void _setLogCallback(callbackFunc);



@interface LCT_GeoLocation : NSObject <CLLocationManagerDelegate> {
  //  callbackFunc logCallback;
}

// Setup the device
+(LCT_GeoLocation*)deviceInstance;


-(void) start_GeoLocation ;
-(void) pause_GeoLocation ;
-(bool) check_ForGPSAvailibilty;

@property (strong, nonatomic) CLLocationManager *lm ;

@property callbackFunc logCallback;

// CLLocationDegrees are just typedef double
@property double latitude ;
@property double longitude ;

@end
