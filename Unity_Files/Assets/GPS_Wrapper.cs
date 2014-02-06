using UnityEngine;
using System.Collections;
using System ;
using System.Runtime.InteropServices ;


[AttributeUsage (AttributeTargets.Method)]
public sealed class MonoPInvokeCallbackAttribute : Attribute {
	public MonoPInvokeCallbackAttribute (Type t) {}
}


public class GPS_Wrapper : MonoBehaviour {

		public static float deviceLatitude = 0f ;		// Between 0 and 90 
		public static float deviceLongitude = 0f ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		// CREATING CALLBACKS
		// We neend to give it a type 
		public delegate void nativeCallback(int type, int index, float value, float val2, float val3);

		[MonoPInvokeCallback(typeof(nativeCallback))]
		public static void Get_Data( float lattitude , float longitude ) {

		}

		[DllImport("__Internal")]
		private static extern void _setLogCallback(nativeCallback callback);

		public static void SetLogCallback(nativeCallback callback) {
				_setLogCallback(callback);
		}


}
