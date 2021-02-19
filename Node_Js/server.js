var websocket = require('ws');

var webSocketServer = new websocket.Server({port : 25500}, ()=>{
    console.log("Ongsa server is running ")
});
var wsList = [];
var roomList =[];
webSocketServer.on("connection",(ws,rq)=>{
  
   console.log("client connected.");
     wsList.push(ws);
    
     ws.on("message",(data)=>{
     var toJsonObj ={
          roomName :"",
          data:""
     }
     toJsonObj = JSON.parse(data);

     if(toJsonObj.eventName == "CreateRoom")
     {
          var isFoundRoom = false;
          for(var i = 0 ; i < roomList.length; i++)
          {
                if(roomList[i].roomName == toJsonObj.data)
                {
                    isFoundRoom = true;
                    break;
                }
          }

          if(isFoundRoom == true)
          {
            var callbackMsg = {
                  eventName:"CreateRoom",
                  data:"fail"
                  }
                  var toJsonObj = JSON.stringify(callbackMsg);
                  ws.send(toJsonStr);

                  console.log("client create room fail.");
          }
          else
          {
                var newRoom = {
                    roomName: toJsonObj.data,
                    wsList[]
                }
                newRoom.wsList.push(ws);
                roomList.push(newRoom);

                var callbackMsg = {
                    eventName:"CreateRoom",
                    data:toJsonObj.data
                }
                ws.send(tojsonStr);
                console.log("client create room success".)
          }
     }
     else if (toJsonObj.eventName == "JoinRoom")
     {
          console.log("client request JoinRoom");
     }
     else if(toJsonObj.eventName == "LeaveRoom")
     {
          var isLeaveSucces = false;
          for(var i = 0; i < roomList.length; i ++)
          {
                for(var j = 0 ; j < roomList[i].wsList.length; j++)
                {
                    if(ws == roomList[i].wsList[j])
                    {
                     roomList[i].wsList.splice(j,1);
                     if(roomList[i].wsList.length <=0)
                      {
                        roomList.splice(i,1);
                       }
                       isLeaveSuccess = true;
                       break;
                    }
                }
          }
          if(isLeaveSuccess)
          {
              var callbackMsg ={
                    eventName :"LeaveRoom",
                    data:"success"
              }
              var tojsonStr = JSON.stringify(callbackMsg);
              ws.send(tojsonStr);

              console.log("leave room succes");
          }
          else
          {
             var callbackMsg = {
                  eventName:"LeaveRoom",
                  data:"fail"
             }
             var tojsonStr = JSON.stringify(callbackMsg)
             ws.send(tojsonStr);

             console.log("leave room fail");
          }
     }

       console.log("sed form client : "+ data);
         Boardcast(data);
     });

      ws.on("close",()=>{
     
             console.log("client disconnect.");

             for(var i = 0; i < roomList.length; i++)
             {
                for(var j = 0; j < roomList[i].wsList.length; j++)
                {
                    if(ws == roomList[i].wsList[j])
                    {
                        roomList[i].wsList.splice(j,1);
                        if(roomList[i].wsList.length <= 0)
                        {
                            roomList.splice(i,1);
                        }
                        break;
                    }
                }
             }
      });
 });

function ArrayRemove(arr,value)
{
return arr.filter((element) =>{
return element != value;
})

}
function Boardcast(data)
{
  for(var i = 0 ; i < wsList.length; i++)
  {
        wsList[i].send(data);
  }
}