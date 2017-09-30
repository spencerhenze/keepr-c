<template>
    <div class="login">

        <v-layout row>
            <v-flex xs12>
                <h2>This is where you log in</h2>
                <v-btn success dark>Login</v-btn>
            </v-flex>
        </v-layout>

    </div>
</template>

<script>
    export default {
        name: 'hello',
        data() {
            return {
                msg: 'Welcome to Your Vue.js App'
            }
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>