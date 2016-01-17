using System.Collections;

public class MoveMod{

	/*===============================*/
	/*依照需要的功能，自行定義此class內容*/
	/*===============================*/


	/*=========================================Members===========================================*/

	/*========================================Components=========================================*/


	/*==========================================Event============================================*/

	//NOTE : 不確定要不要
	public event Action<T> onUndo;
	public event Action<T> onCommand;
	


	/*=====================================Public Function=======================================*/
	public Func<T, bool> OnInput(T inputInfo){

		switch (inputInfo.type){
			case "mouseRightDown":
				return onInputDown(inputInfo);

			case "mouseLeftUp":
				return onInputUp(inputInfo);

			default:

				return false;

		}

	}
	
	
	
	/*====================================Private Function=======================================*/

	//操作按下
	private Func<T, bool> onInputDown(T inputInfo){
		//自定義內容

		return true/*已取用(不傳給下一個)*/   /*或者還要繼續傳下去則 false */
	}	

	//操作彈起
	private Func<T, bool> onInputUp(T inputInfo){
		//自定義內容

		return true/*已取用(不傳給下一個)*/   /*或者還要繼續傳下去則 false */
	}



}