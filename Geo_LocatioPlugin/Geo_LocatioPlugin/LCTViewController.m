//
//  LCTViewController.m
//  Geo_LocatioPlugin
//
//  Created by L on 2/5/2014.
//  Copyright (c) 2014 ElectrikSheep. All rights reserved.
//

#import "LCTViewController.h"

@interface LCTViewController ()

@end

@implementation LCTViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    [[LCT_GeoLocation sharedInstance] startRecording_Location ];
    
	// Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
