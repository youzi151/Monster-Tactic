using System.Collections;
using System.Collections.Generic;

public class InputCtrl{

	/*Members*/

	//正在偵聽操作的物件清單
	public List<T> listenerList;


	/*Components*/


	/*Event*/


	/*Public Function*/
	//加入偵聽者  params: 偵聽者本身, 優先度
	public void addListener(T listener, int priority){}

	//移除偵聽者  params: 偵聽者本身
	public void removeListener(T listener){}

	/*Private Function*/



}