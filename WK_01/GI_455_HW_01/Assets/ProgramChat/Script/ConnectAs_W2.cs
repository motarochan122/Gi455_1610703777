using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

namespace ChatWebSocket
{
    public class ConnectAs_W2 : MonoBehaviour
    {
        public struct SocketEvent
        {
            public string eventName;
            public string data;
          public SocketEvent(string eventName, string data)
          {
            this.eventName = eventName;
            this.data = data;
          }
        }


        class MessageData
        {
            public string username;
            public string message;
        }
        public InputField inputField_IP;
        public InputField inputField_Port;
        public InputField inputField_Username;
        public InputField inputField_messageChat;

        public WebSocket webSocket;

        public GameObject connectWindow;
        public GameObject chatWindow;
        public GameObject choiceWindow;
        public GameObject createWindow;
        public GameObject joinWindow;

        private string tempMessageString;

        public delegate void DelegateHandle(SocketEvent result);

        public DelegateHandle OnCreateRoom;
        public DelegateHandle OnJoinRoom;
        public DelegateHandle OnLeaveRoom;

        public Text sendMessage;
        public Text reciveMessage;

        public void start()
        {
            webSocket.OnMessage += OnMessage;
        }
        public void OnConnect()
        {
            webSocket = new WebSocket("ws://" + inputField_IP.text + ":" + inputField_Port.text + "/");
            webSocket.Connect();
            webSocket.Send("Test");

            connectWindow.SetActive(false);
            chatWindow.SetActive(false);
            choiceWindow.SetActive(true);
            createWindow.SetActive(false);
            joinWindow.SetActive(false);

        }
        public void OnChooseCreate()
        {
            choiceWindow.SetActive(false);
            createWindow.SetActive(true);
        }
        public void OnChooseJoin()
        {
            choiceWindow.SetActive(false);
            joinWindow.SetActive(true);
        }
        public void CreateRoom(string roomName)
        {
            createWindow.SetActive(false);
            chatWindow.SetActive(true);

            SocketEvent socketEvent = new SocketEvent("CreateRoom",roomName)
                string toJsonStr = JsonUtility.ToJson(SocketEvent);

            webSocket.Send(
        }
        public void OnJoin()
        {
            joinWindowchat.SetActive(false);
            chatWindow.SetActive(true);
        }
        public void OnSend()
        {
            MessageData messageData = new MessageData();
            messageData.username = inputField_Username.text;
            messageData.message = inputField_messageChat.text;

            string toJsonStr = JsonUtility.ToJson(messageData);
            sendMessage.text = ("" + inputField_messageChat.text);
            webSocket.Send(toJsonStr);

            inputField_messageChat.text = "";
            //webSocket.Send(sendMessage.text);


        }
        private void Update()
        {
            //if (tempMessageString != null && tempMessageString != "")
            if (string.IsNullOrEmpty(tempMessageString) == false)
            {
                MessageData reciveMessageData = JsonUtility.FromJson<MessageData>(tempMessageString);
                if (reciveMessageData.username == inputField_Username.text)
                {
                    sendMessage.text += reciveMessageData.message + "\n";
                }
                else
                {
                    reciveMessage.text += reciveMessageData.message + "\n";
                }
            }
            tempMessageString = "";
        }
        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log(messageEventArgs.Data);
            tempMessageString = messageEventArgs.Data;
        }


    }
}
