const signalR = require("@microsoft/signalr");
export default class SignalRService {
  connection;
  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:5001/vuejsHub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();
  }

  getConnection() {
    return this.connection;
  }
}
