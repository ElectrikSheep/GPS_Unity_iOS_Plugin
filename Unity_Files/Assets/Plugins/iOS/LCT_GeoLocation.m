//
//  LCT_GeoLocation.m
//  Geo_LocatioPlugin
//
//  Created by L on 2/5/2014.
//  Copyright (c) 2014 ElectrikSheep. All rights reserved.
//

#import "LCT_GeoLocation.h"
#define INSTANCE [LCT_GeoLocation deviceInstance]

void _setLogCallback(callbackFunc cb) {
    [INSTANCE setLogCallback:cb];
}


void _pauseGeoLocation() {
    [INSTANCE pause_GeoLocation];
}
void _startGeoLocation() {
    [INSTANCE start_GeoLocation];
}




@implementation LCT_GeoLocation

static LCT_GeoLocation *deviceInstance = nil;
+(LCT_GeoLocation*)deviceInstance {
    if( !deviceInstance )
        deviceInstance = [[LCT_GeoLocation alloc] init];
    
    return deviceInstance;
}


-(id) init {
    self.latitude = 100 ; // Value is between -90 and 90
    self.longitude = 200 ; // Values is between -180 and 180
    
    self.lm = [[CLLocationManager alloc] init];
    self.lm.delegate        = self;  //SET YOUR DELEGATE HERE
    self.lm.desiredAccuracy = kCLLocationAccuracyBest; //SET THIS TO SPECIFY THE ACCURACY
    
    // Try to see if just calling start_Geolocation will create the instance and then launch the update
    //[self.lm startUpdatingLocation ] ;
    
    return self ;
}

-(void) start_GeoLocation {
    [self.lm startUpdatingLocation ] ;
}

-(void) pause_GeoLocation {
    [self.lm stopUpdatingLocation ] ;
}

- (void)locationManager:(CLLocationManager *)manager
    didUpdateToLocation:(CLLocation *)newLocation
           fromLocation:(CLLocation *)oldLocation{
    NSLog(@"%f - %f", newLocation.coordinate.latitude, newLocation.coordinate.longitude ) ;
    
    self.longitude = newLocation.coordinate.longitude;
    self.latitude = newLocation.coordinate.latitude;
    
    self.logCallback( self.longitude, self.latitude);
}

@end
