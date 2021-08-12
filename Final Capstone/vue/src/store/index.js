import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    showButton: true,
    property: {
      propertyId: 0,
      landlordId: 0,
      description: "",
      addressLineOne: "",
      addressLineTwo: "",
      city: "",
      state: "",
      zipCode: "",
      price: 0,
      dateAvailable: "",
      available: false,
      beds: 0,
      baths: 0,
      thumbnail: "",
      images: []
    },
    
    image: {
      imageId: 0,
      propertyId: 0,
      link: "",
      thumbnail: false
    },

    task: {
      taskId: 0,
      employeeId: 0,
      propertyId: 0,
      isUrgent: false,
      taskDescription: "",
      dateEntered: "",
      dateScheduled: "",
      taskStatus: ""
    },

    tasks: [],
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_PROPERTY(state, data){
      state.property = data;
    },
    SET_TASK(state, data){
      state.task = data;
    },
    ADD_PROPERTIES_IMAGE(state, image){
      state.property.images.push(image);
    },
    SET_THUMBNAIL(state, thumbnail){
      state.property.thumbnail = thumbnail;
      state.showButton = false;
    },
    SET_TASKS(state, data) {
      state.tasks = data;
    },

    
  }
})
