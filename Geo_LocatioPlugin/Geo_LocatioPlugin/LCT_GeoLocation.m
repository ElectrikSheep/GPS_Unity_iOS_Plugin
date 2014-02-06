//
//  LCT_GeoLocation.m
//  Geo_LocatioPlugin
//
//  Created by L on 2/5/2014.
//  Copyright (c) 2014 ElectrikSheep. All rights reserved.
//

#import "LCT_GeoLocation.h"

@implementation LCT_GeoLocation

static LCT_GeoLocation *sharedInstance = nil;
+(LCT_GeoLocation*)sharedInstance {
    if( !sharedInstance )
        sharedInstance = [[LCT_GeoLocation alloc] init];
    
    return sharedInstance;
}


-(id) init {
    self.lm = [[CLLocationManager alloc] init];
    self.lm.delegate        = self;  //SET YOUR DELEGATE HERE
    self.lm.desiredAccuracy = kCLLocationAccuracyBest; //SET THIS TO SPECIFY THE ACCURACY
    
    return self ;
}

-(void) startRecording_Location {
    [self.lm startUpdatingLocation ] ;
}

- (void)locationManager:(CLLocationManager *)manager
    didUpdateToLocation:(CLLocation *)newLocation
           fromLocation:(CLLocation *)oldLocation{
    NSLog(@"Do stuff") ;
    NSLog(@"%f - %f", newLocation.coordinate.latitude, newLocation.coordinate.longitude ) ;
}

@end
