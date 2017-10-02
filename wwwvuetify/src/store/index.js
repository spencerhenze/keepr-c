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
        results: [
            { title: 'Boise Homes', src: '//res.cloudinary.com/dvh7zccln/image/upload/v1506560973/SHP_0282_e5rzfg.jpg', flex: 12 },
            { title: 'Mountain Therapy', src: '//res.cloudinary.com/dvh7zccln/image/upload/v1501022397/SHP_0604_x1szrl.jpg', flex: 6 },
            { title: 'Sick Gnar', src: '//res.cloudinary.com/dvh7zccln/image/upload/v1500221424/SHP_1220_e3cjkd.jpg', flex: 6 }
        ],
    
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