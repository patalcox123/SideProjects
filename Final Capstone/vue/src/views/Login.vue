<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="title">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <label id="username" for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label id="password" for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <router-link id="register" :to="{ name: 'register' }">Need an account?</router-link>
      <button id="submit" type="submit">Sign in</button>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
  #login {
    padding-top: 50px;
    text-align: center;
    background-image: url("../assets/images/login-bg.jpg");
    background-repeat: no-repeat;
    background-position: top;
    display: grid; 
    grid-template-columns: 1fr 1fr 1fr; 
    grid-template-rows: 1fr; 
    max-width: 100%;
    gap: 0px 0px; 
    grid-area: login;
    grid-template-areas: 
      ". hi .";
  }
  #login > .form-signin{
    display: grid;
    text-align: center;
    grid-area: hi;
    grid-template-columns: 1fr; 
    grid-template-rows: 1fr 1fr 1fr 1fr 1fr; 
    gap: 0px 0px; 
    max-width: 100%;
    grid-template-areas: 
      "title "
      "username"
      "password"
      "register"
      "submit";
  }
  #login > .form-signin > .title {
   font-size: 2vw;
   color: #468189;
   text-decoration: underline #031926;
   grid-area: title;
  }
  .form-signin > .title > .alert {
    color: #468189;
  }
  #username {
   font-size: 1vw;
   color: #468189;
   margin-bottom: 5px;
   grid-area: username;
  }
  #password {
   font-size: 1vw;
   color: #468189;
   margin-top: 5px;
   grid-area: password;
  }
  #register {
   font-size: 1vw;
   color: #468189;
   margin-bottom: 10px;
   justify-self: center;
   grid-area: register;
  }
  #submit {
    background-color: #9dbebb91;
    color: #031926;
    width: 35%;
    height: 50px;
    border: solid 1px #9dbebb91;
    justify-self: center;
    grid-area: submit;
  }
</style>
