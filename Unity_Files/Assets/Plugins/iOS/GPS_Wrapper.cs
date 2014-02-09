using UnityEngine;
using System.Collections;
using System ;
using System.Runtime.InteropServices ;


[AttributeUsage (AttributeTargets.Method)]
public sealed class MonoPInvokeCallbackAttribute : Attribute {
	public MonoPInvokeCallbackAttribute (Type t) {}
}


public class GPS_Wrapper : MonoBehaviour {

		public double deviceLatitude = 0f ;		// Between 0 and 90 
		public double deviceLongitude = 0f ;

		// I want this class as a Singleton
		private static GPS_Wrapper _instance;

		public static GPS_Wrapper Instance {
				get {
						return _instance;
				}
		}

		private void Start() {
				if( _instance == null )
						_instance = new GPS_Wrapper();
				#if !UNITY_EDITOR
				SetLogCallback( Get_Data );
				#endif
		}

		// CREATING CALLBACKS
		// We need to give it a type 
		public delegate void nativeCallback ( double latitude, double longitude );

		[MonoPInvokeCallback(typeof(nativeCallback))]
		public static void Get_Data( double lattitude , double longitude ) {
				Instance.deviceLatitude = lattitude ;
				Instance.deviceLongitude = longitude ;
		}

		[DllImport("__Internal")]
		private static extern void _setLogCallback(nativeCallback callback);

		public void SetLogCallback(nativeCallback callback) {
				_setLogCallback(callback);
		}

	

		[DllImport("__Internal")]
		private static extern void _pauseGeoLocation() ;
		public void PauseGeoLocation() {
				#if !UNITY_EDITOR
				_pauseGeoLocation () ;
				#endif
		}

		[DllImport("__Internal")]
		private static extern void _startGeoLocation();
		public void StartGeoLocation (){
				#if !UNITY_EDITOR
				_startGeoLocation() ;
				#endif 
		}

		[DllImport("__Internal")]
		private static extern bool _checkForUserPermission();
		public bool Check_ForUserPermission (){
				#if !UNITY_EDITOR
				return _checkForUserPermission() ;
				#endif 
				return false ;
		}






}
