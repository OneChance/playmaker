using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{		
		[ActionCategory("myAction")]
		public class ExceptKey : FsmStateAction
		{
				[RequiredField]
				public KeyCode
						key;
				public FsmEvent OtherEvent;
				public FsmEvent ExceptKeyEvent;
	
				public override void Reset ()
				{
						OtherEvent = null;
						ExceptKeyEvent = null;
						key = KeyCode.None;
				}
	
				public override void OnUpdate ()
				{
						if (Input.GetKeyDown (key)) {
								Fsm.Event (ExceptKeyEvent);			
						} else {
								if (Input.anyKeyDown) {
										Fsm.Event (OtherEvent);	
								}			
						}
				}
		}
}
