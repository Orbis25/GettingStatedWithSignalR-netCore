import Vue from "vue";
import Vuex from "vuex";
import SignalRService from "../service/signalRService";
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    signalRConnection: new SignalRService().getConnection()
  },
  getters: {
    getConnectionSignalR : (state) => state.signalRConnection
  }
});
