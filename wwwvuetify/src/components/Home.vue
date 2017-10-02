<template>
  <div class="home">
    <v-container fluid grid-list-md class="transparent">
      <v-layout row wrap>

        <!-- load results -->
        <v-flex  v-for="card in results" :key="card.title">
          <v-card>
            <v-card-media :src="card.src" height="200px">
              <v-container fill-height fluid>
                <v-layout fill-height>
                  <v-flex xs12 align-end flexbox>
                    <span class="headline white--text" v-text="card.title"></span>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-media>
            <v-card-actions class="white">
              <v-spacer></v-spacer>

              <v-btn icon>
                <v-icon class="grey--text">favorite</v-icon>
              </v-btn>
              <v-btn icon>
                <v-icon class="grey--text">bookmark</v-icon>
              </v-btn>
              <v-btn icon>
                <v-icon class="grey--text">share</v-icon>
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
        <!-- end load results -->

      </v-layout>
    </v-container>
  </div>
</template>

<script>
  export default {
    name: 'home',
    data() {
      return {
        msg: 'Welcome to Your Vue.js App'
      }
    },

    computed: {
      results() {
        return this.$store.state.results;
      }
    }
  }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1,
  h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>