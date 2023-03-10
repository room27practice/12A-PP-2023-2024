<script>
// import Spinner from './Spinderman.vue'
const weatherURL = 'https://localhost:44395/WeatherForecast/'
const minionsURL = 'https://localhost:44395/Minions/All'
const postURL = 'https://jsonplaceholder.typicode.com/posts'
export default {
  data() {
    return {
      count: 0,
      minionsLoaded: null
    }
  },
  methods: {
    increaseNumber() {
      const a = 5
      this.count++
      console.log('Mashala')
    },
    async getPosts() {
      const response = await fetch(minionsURL)
      this.minionsLoaded = await response.json()
      //  debugger;
    }
  },
  async mounted() {
    await this.getPosts()
  }
}
</script>

<template>
  <div v-if="!minionsLoaded" class="spinner-border" role="status">
  <span class="visually-hidden">Loading...</span>
</div>

  <ul v-else>
    <!-- {{ downloaded }} -->
    <li v-for="m in minionsLoaded">
      <h3>{{ m.minionName }}</h3>
     <p> It is {{ m.age }} years old.</p>
     <p> Minions is in service of {{ m.villainNames.length }} villains.</p>
     <p>Their names are: </p>
      <ul>
        <li v-for="vname in m.villainNames">{{ vname }}</li>
      </ul> 
      <p>Town is {{m.city}}.</p>
    </li>
  </ul>

  <button class="btn btn-primary" @click="increaseNumber()">You clicked me {{ count }} times.</button>
</template>


<style scoped>
.my-btn {
  border-radius: 1em;
  background-color: aquamarine;
}
</style>