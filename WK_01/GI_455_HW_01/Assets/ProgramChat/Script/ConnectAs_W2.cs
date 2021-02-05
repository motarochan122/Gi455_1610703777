using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;



public class ConnectAs_W2 : MonoBehaviour
{
    public InputField inputField_IP;
    public InputField inputField_Port;
    public InputField messageChat;
    public  WebSocket webSocket;

    public GameObject connectWindow;
    public GameObject chatWindow;
  

    public Text message;
   
   
 public void OnConnect()
 {
     
            webSocket = new WebSocket("ws://"+inputField_IP.text+":"+inputField_Port.text+"/");
            webSocket.Connect();
            webSocket.Send("Test");

        connectWindow.SetActive(false);
            chatWindow.SetActive(true);
        
   
 }
    public void OnMessage(object sender, MessageEventArgs messageEventArgs)
    {
        Debug.Log("Message form server :" + messageEventArgs.Data);
       
    }
    public void  OnSend()
    {
        message.text = (""+ messageChat.text);
        webSocket.Send(message.text);
        
    }

}
