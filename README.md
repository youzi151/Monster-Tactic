# Monster-Tactic

基於《魔躍》的戰棋/策略遊戲架構，新手學習用<br/>
A tactical game architecture for beginner


## 起源
&nbsp;&nbsp;&nbsp;&nbsp;撰寫《魔躍》時，因為是初次碰到戰棋/策略類的遊戲，<br/>
需要一個有架構，而不是物理或直接順著寫就可以運作的程式。<br/>
因此做了一些設計，並修修改改。<br/>
為了讓之後需要寫到戰棋/策略類遊戲的初學者，<br/>
可以更順利且專心的撰寫遊戲本身，故將寫《魔躍》時用到的架構整理成集。<br/>
也同時做一些增修即補強。<br/>
<br/>
&nbsp;&nbsp;&nbsp;&nbsp;歡迎各位以此架構進行遊戲開發，也希望在過程中若有什麼建議或疑惑，<br/>
可以多多提供意見，讓這個架構可以運用得更靈活，使戰棋/策略類遊戲更加有趣。<br/>

## 概敘

&nbsp;&nbsp;&nbsp;&nbsp;首先將以從內到外的方式，一步一步撰寫程式、新增功能。<br/>

###一、取得玩家操作
[用到的script：InputUtil、InputCtrl]<br/>
<br/>
&nbsp;&nbsp;&nbsp;&nbsp;一般寫Unity遊戲時，會習慣性直接把操作寫在主角身上的script，<br/>
並且如果鏡頭要旋轉，就會在鏡頭上的script寫入操作的功能。<br/>
但這樣一來，不僅能操作的東西變多時會不好管理，<br/>
當有一個操作被兩個script同時偵聽時，行為重疊、衝突的狀況也會發生。<br/>
<br/>
&nbsp;&nbsp;&nbsp;&nbsp;所以為了解決這個問題，我那時候想到的方式是：<br/>
先撰寫InputUtil，讓一些操作可以包裝成更高層的操作資訊，<br/>
例如Unity中的Input.MouseDown->Raycast->RaycastHit...等，<br/>
可以直接包裝成一個事件onHit或isHit()，方便使用。<br/>
<br/>
&nbsp;&nbsp;&nbsp;&nbsp;再到InputCtrl中，用呼叫InputUtil來檢查遊戲內需要用到的操作。<br/>
並將需要偵聽Input操作的script，以Listener的方式註冊到InputCtrl中，同時附帶該script的優先度。<br/>
那麼當檢查到某個Input操作發生時，只要依照註冊時的優先度，依序告知每個script，<br/>
讓每一個script根據Input操作執行自己的功能(或不執行)<br/>
並詢問該操作是否還能被其他有註冊Listener的script使用。<br/>
若能則繼續告知下一位Listener，若不能則停止傳遞、結束流程。<br/>
<br/>
例如：<br/>
1.檢查到滑鼠左鍵點擊某物件。<br/>
2.告知優先度no.1 Listener：控制棋子移動的script。<br/>
3.該script得知某物件並不是棋子，回傳給InputCtrl，告知可以傳給下一位Listener。<br/>
4.InputCtrl傳給優先度no.2 Listener：說明場上物件資訊的script。<br/>
5.該script得知某物件可描述資訊，則執行自身功能，並且回傳給InputCtrl，告知不要再傳給下一位Listener。<br/>
6.InputCtrl得知已被攔截，不再傳給優先度no.3以下的Listener<br/>



###二、移動棋子
[用到的script：MapObj、MapUtil、ChessObj、MoveMod]
<br/>

## Coding Style說明

### 命名方式

#### 類別後綴詞

<b>Obj</b>&nbsp;&nbsp;&nbsp;&nbsp;基本型的腳本，有自己獨立運作的功能。

<b>Data</b>&nbsp;&nbsp;&nbsp;&nbsp;通常用於傳遞資料、被呼叫的物件。

<b>Ctrl</b>&nbsp;&nbsp;&nbsp;&nbsp;會控制整個進程的重大物件。

<b>Mod</b>&nbsp;&nbsp;&nbsp;&nbsp;功能模塊，較不主動執行。

<b>Comp</b>(Component)&nbsp;&nbsp;&nbsp;&nbsp;小型的功能模塊，通常是有可替換性的。


<b>Manager</b>&nbsp;&nbsp;&nbsp;&nbsp;資源管理。

<b>Util</b>&nbsp;&nbsp;&nbsp;&nbsp;公用。

<b>其他</b>&nbsp;&nbsp;&nbsp;&nbsp;如Process的Node、Condition、Event...等，會讓該套功能模塊來自行定義。