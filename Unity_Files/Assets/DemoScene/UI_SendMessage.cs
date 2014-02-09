using UnityEngine;
using System.Collections;

public class UI_SendMessage : MonoBehaviour {

		[SerializeField] private string Message_ToSend ;
		[SerializeField] private GameObject Target;

		public void OnPress( bool isPressed ) {
				if( isPressed ) return ;

				Target.SendMessage( Message_ToSend, SendMessageOptions.RequireReceiver ) ;
				gameObject.SetActive( false ) ;
		}
}
