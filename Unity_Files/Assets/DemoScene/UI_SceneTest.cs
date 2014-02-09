﻿﻿using UnityEngine;
using System.Collections;

public class UI_SceneTest : MonoBehaviour {



		[SerializeField] private UILabel _labelLatitude ;
		[SerializeField] private UILabel _labelLongitude ;	

		private bool geoLocation_Started = false ;

		// Update is called once per frame
		private void Update () {
		
				if( !geoLocation_Started ) return ;

				_labelLatitude.text = "Latitude :"+ GPS_Wrapper.Instance.deviceLatitude ;
				_labelLongitude.text = "Longitude :"+ GPS_Wrapper.Instance.deviceLongitude ;
		}


		public void Start_GeoLocation() {
				geoLocation_Started = true ;

				_labelLatitude.gameObject.SetActive( true );
				_labelLongitude.gameObject.SetActive( true );

				GPS_Wrapper.Instance.StartGeoLocation() ;
		}
}
