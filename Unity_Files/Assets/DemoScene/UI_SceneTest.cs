﻿﻿using UnityEngine;
using System.Collections;

public class UI_SceneTest : MonoBehaviour {



		[SerializeField] private GUIText _labelLatitude ;
		[SerializeField] private GUIText _labelLongitude ;	

		[SerializeField] private GUIText _errorMessage ;	


		private bool geoLocation_Started = false ;

		private Rect btnRect ;

		private void Start() {
				btnRect = new Rect( 0f, 0f, Screen.width, Screen.height/10f ) ;

				_labelLatitude.text = "Latitude :\nNaN" ;
				_labelLongitude.text = "Longitude :\nNaN" ;
		}


		// Update is called once per frame
		private void Update () {
		
				// I don't know why, but if you start an iOS plugin at the same time you start your Unity app
				// It will crash
				if( !geoLocation_Started ) return ;

				_labelLatitude.text = "Latitude :\n"+ GPS_Wrapper.Instance.deviceLatitude ;
				_labelLongitude.text = "Longitude :\n"+ GPS_Wrapper.Instance.deviceLongitude ;
		}

		private void OnGUI() {

				if( GUI.Button(btnRect, geoLocation_Started ? "Stop Geolocation" : "Start GeoLocation" )){
						if( geoLocation_Started ) Pause_GeoLocation() ;
						else Start_GeoLocation() ;
				}
		}



		public void Start_GeoLocation() {
				// I am pretty sure I should launch a coroutine here but meh fuck it
				GPS_Wrapper.Instance.StartGeoLocation() ;

				if( !GPS_Wrapper.Instance.Check_ForUserPermission() ) {
						geoLocation_Started = false  ;
						_errorMessage.gameObject.SetActive( true ) ;

						_labelLatitude.text = "Latitude :\nNaN" ;
						_labelLongitude.text = "Longitude :\nNaN" ;
				} else {
						_errorMessage.gameObject.SetActive( false ) ;
						geoLocation_Started = true ;
				}
		}

		public void Pause_GeoLocation() {
				geoLocation_Started = false ;
				GPS_Wrapper.Instance.PauseGeoLocation() ;
		}
}
