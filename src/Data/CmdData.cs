using System.Collections;

public class CmdData{

	/*==============Members===============*/

	/*=============Components=============*/


	/*================Event===============*/
	public event Action<T> onDo;
	public event Action<T> onUndo;
	public event Action<T> onCancel;
	public event Action<T> onError;
	


	/*===========Public Function==========*/
	//執行
	public void Do(){}

	//復原
	public void Undo(){}
	
	//取消
	public void Cancel(){}
	
	

	/*==========Private Function==========*/



}