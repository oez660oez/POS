# 大碗公點餐系統+後台(POS系統)

此Windows Forms專案整合前台點餐與後台管理功能。系統提供直覺的操作介面，支援商品訂購表單、會員註冊維護、商品管理、訂單管理、系統設定管理等核心功能。

歡迎使用測試帳號登入使用，帳密如下：
```
會員：
帳號：MrsPuff
密碼：SB7W743f
```
```
員工：
帳號：Lobster
密碼：DA6rU5zh
```
```
店長：
帳號：FlyingDutchman
密碼：v5K5whnb
```

## 功能列表

- 訂購功能：
  - 商品瀏覽與搜尋
  - 購物車管理、結帳

- 商品管理：
  - 商品新增與修改(商品資訊、圖檔)
  - 商品上下架管理(正常、停賣)

- 會員系統：
  - 會員註冊與登入
  - 會員資料查詢修改
  - 會員歷史訂單查詢

- 訂單管理：
  - 訂單審核
  - 訂單狀態追蹤與修改

- 員工管理：
  - 員工打卡系統與店長確認打卡進度
  - 權限分級管理（店長、員工、會員）
  - 系統操作時間設定

- 報表分析：
  - 計算營業額報告(年、月、日、指定區間)

## 影片展示Demo

[![影片標題](https://img.youtube.com/vi/PiyiQy_avg8/0.jpg)](https://youtu.be/PiyiQy_avg8)
  
## 執行需求
- 建議Windows 10 或以上版本
- 已安裝 .NET Framework 4.7.2
- SQL Server (建議 2019 或以上版本，Express 版本即可)

## 使用說明
1. 至 Github 頁面(https://github.com/oez660oez/POS) 點擊 Code 後 Download ZIP 下載完畢解壓縮
2. 執行 SQL Server Management Studio時確保伺服器名稱為(localhost或是.或裝置名稱)連線
3. 執行 SQL 資料夾中的IceShopData指令碼
4. 開啟 Release 資料夾執行 IceShop.exe 即可使用

## 注意事項
- 所有檔案需放在同一個資料夾中
- 如果缺少 .NET Framework 4.7.2，可以從微軟官網下載安裝
  
## Screen Photo

![登入](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Login.JPG)
![註冊](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Register.JPG)
![首頁](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Index.JPG)
![商品細項](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/ProductDetail.JPG)
![會員中心](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/MemberCenter.JPG)
![購物車](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/ShoppingCart.JPG)
![結帳](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Purchase.JPG)
![訂購單](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Export.JPG)
![員工後台](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend01.JPG)
![員工會員搜尋](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_MemberSearch.JPG)
![員工訂單查詢](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_OrderSearch.JPG)
![新增商品](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_ProductCRUD.JPG)
![員工打卡](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_Clockin.JPG)
![店長後台](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend02.JPG)
![店長會員搜尋](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_MemberSearch02.JPG)
![店長打卡](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_Clockin02.JPG)
![報表](https://github.com/oez660oez/POS/blob/master/Images/ScreenShot/Backend_Calculate.JPG)

## 使用工具

- [Visual Studio 2022](https://visualstudio.microsoft.com/zh-hant/vs/) - 主要開發環境
- Windows Forms (.NET Framework) - 使用者介面框架
- [SQL Server 2022](https://www.microsoft.com/zh-tw/sql-server/sql-server-downloads) - 資料庫管理系統
- C# - 程式語言
- Windows Forms Controls - UI元件
