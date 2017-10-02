import vue from 'vue'
import vuex from 'vuex'
import $ from 'jquery'

var production = !window.location.host.includes('localhost')
var ip = production ? '//deployment location' : '//localhost:5000'

vue.use(vuex)

var store = new vuex.Store({
    state: {
        user: {},
        loggedIn: false,
        results: [],
    
    },
    mutations: {
        toggleLoggedIn(store, value) {
            store.loggedIn = !store.loggedIn;
        }

    },
    actions: {

    },


})

export default store;