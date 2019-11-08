<template>
  <div class="about">
    <h1>This is an list page</h1>
    <div>
      <ul>
        <li v-for="(item,index) in list" :key="index">{{item}}</li><br>
      </ul>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "list",
  data: () => ({
    connection: null,
    list: []
  }),
  created() {
    this.connection = this.getConnection();
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
  mounted() {
    this.connection.on("AddEvent", name => {
      this.list.push(name);
    });
  },
  methods: {
    ...mapGetters({
      getConnection: "getConnectionSignalR"
    })
  }
};
</script>

