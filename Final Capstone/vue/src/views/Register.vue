<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="title">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label id="role" for="role" class="sr-only">Role</label>
      <select
        id="role"
        class="form-control"
        placeholder="Role"
        v-model="user.role"
        required
        autofocus>
        <option value="" selected disabled>Role</option>
        <option v-for="role in roles" v-bind:value="role" v-bind:key="role">{{ role }}</option>
      </select>
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
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <router-link id="login" :to="{ name: 'login' }">Have an account?</router-link>
      <button id="submit" class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
    </form>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: '',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
      roles: ['renter', 'landlord', 'employee']
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style scoped>
  #register {
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
  #register > .form-register {
    display: grid;
    text-align: center;
    grid-area: hi;
    grid-template-columns: 1fr; 
    grid-template-rows: 1fr 1fr 1fr 1fr 1fr 1fr 1fr; 
    gap: 0px 0px; 
    max-width: 100%;
    grid-template-areas:
      "title" 
      "role"
      "username"
      "password"
      "confirmPassword"
      "login"
      "submit";
  }
   #register > .form-register > .title {
   font-size: 2vw;
   color: #031926;
   text-decoration: underline #031926;
   grid-area: title;
  }
  #role {
   font-size: 1vw;
   color: #468189;
   margin-bottom: 10px;
   grid-area: role;
  }
  #username {
   font-size: 1vw;
   color: #468189;
   margin-bottom: 10px;
   grid-area: username;
  }
  #password {
   font-size: 1vw;
   color: #468189;
   margin-bottom: 10px;
   grid-area: password;
  }
  #confirmPassword {
   font-size: 1vw;
   color: #468189;
   margin-bottom: 10px;
   grid-area: confirmPassword;
  }
  #login {
   font-size: 1vw;
   color: #031926;
   grid-area: login;
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
