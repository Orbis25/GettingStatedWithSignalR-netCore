<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <h1>WELCOME TO VUEJS AND SIGNALR .NETCORE</h1>
    <br />
    <input type="text" v-model="name" required />
    <br />
    <button @click="add()">Enviar a la lista</button>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "home",
  data: () => ({
    name: null,
    connection: null
  }),
  created() {
    this.connection = this.getConnection()
    this.connection
      .start()
      .then(() => {
        /* eslint-disable */
        console.log("conected");
      })
      .catch(err => {
        /* eslint-disable */
        console.log("error => " + err);
      });
  },
  methods: {
    ...mapGetters({
      getConnection:"getConnectionSignalR"
    }),
    add() {
      this.connection.invoke("Add", this.name).catch(err => {
        /* eslint-disable */
        console.log("error => " + err);
      });
    }
  }
};
</script>
