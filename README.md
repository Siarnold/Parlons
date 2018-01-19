# Parlons

> A central server-based P2P chatting system  
> As the big assignment for the course of Computer Networks and Applications in 2017 Fall, Tsinghua University  
> 'Parlons' is French, meaning 'Let's Talk'  
> Siarnold, 2017 - 2018  
> Contact: siarnold@foxmail.com  

------

## 特此声明
* All codes are released here under the GNU licenses as free documents. Anyone who promises the freedom of these documents is granted with the rights to read, use or modify these codes.

## 运行环境

* 使用C#语言完成
* 编写、调试环境为Visual Studio 2012
* 运行需要安装Microsoft .NET Framework 4.0
* Emoji路径修改在FormParlons第37行EmojiDirectory中可设置
* Release时将此路径设为当前目录".\Emoji"，故请将可执行文件Parlons.exe与Emoji文件夹置于相同路径下
* 工程文件设置Emoji路径为Resources文件夹，故工程可直接运行

## 各文件功能

* FormLogIn.cs
  - 登录界面
* FormParlons.cs
  - 主界面与主逻辑
  - 支持好友添加、好友聊天、文件发送、表情发送等功能
  - 支持新建群组、群组聊天等多人功能
  - 定义通讯格式并据此处理接收到的消息
* P2PConnection.cs
  - P2P连接逻辑代码：设置**通讯的端口号**
  - 监听的发起
  - P2P字节发送
* Program.cs
  - 程序默认启动文件
* ServerConnection.cs
  - 中央服务器连接逻辑代码
  - 向服务器发送请求并返回响应字符串
* UserControEmoji.cs
  - 自定义控件：PictureBox功能 + 表情名信息
* UserControlFriend.cs
  - 自定义控件
  - 界面部分：好友列表显示、聊天窗口、消息发送窗口
  - 逻辑部分：列表中高亮等
* UserControlGroup.cs
  - 自定义控件
  - 界面部分：群在列表显示、聊天窗口、消息发送窗口
  - 逻辑部分：列表中高亮等
* UserControlReceiveImage.cs
  - 自定义控件：实现接收图片预览功能
* UserControlReceiveSession.cs
  - 自定义控件：实现接收消息的格式
* UserControlSendImage.cs
  - 自定义控件：实现发送图片预览功能
* UserControlSendSession.cs
  - 自定义控件：实现发送消息的格式
