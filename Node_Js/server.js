var websocket = require('ws');
var wsList = [];
var webSocketServer = new websocket.Server ({port : 25500}, ()=>{
   console.log("Ongsa server is running ")
});
webSocketServer.on("connection",(ws,rq)=>{
  console.log("client connected.");
  wsList.push(ws);
  ws.on("message",(data)=>{

  console.log("sed form client : "+ data);
  Boardcast(data);
});

  ws.on("close",()=>{
     
             console.log("client disconnect.");
  });

});

function ArrayRemove(arr,value)
{
return arr.filter((element) =>{
return element != value;
})

}
function Boardcast(Data)
{
  for(var i = 0 ; i < wsList.lenght; i++)
  {
        wsList[i].send(data);
  }
}