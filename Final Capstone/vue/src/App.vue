

<template>
  <div id="app">
    <div id="navbar">
      <b-navbar fixed-top>
        <template #brand>
          <router-link :to="{ name: 'home'}">
          <img
            id="logo"
            src="../src/assets/images/logosingular.jpg"
            alt="Logo"
            
          />
          </router-link>
        </template>
        <template #start>
          <b-navbar-item class="text" tag="router-link" :to="{ path: '/' }">
            Home
          </b-navbar-item>
          <b-navbar-item v-if="$store.state.token != ''" class="text" tag="router-link" :to="{ name: 'info' }"> 
            My Profile 
          </b-navbar-item>
          <b-navbar-dropdown v-if="$store.state.user.role == 'landlord'" class="text" label="Landlord">
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'myproperties' }">My Properties</b-navbar-item>
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'addproperty' }">Add A Property</b-navbar-item>
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'mymaintenance' }">Maintenance</b-navbar-item>
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'applications' }">Applications</b-navbar-item>
             <b-navbar-item class="text" tag="router-link" :to="{ name: 'employees' }">Employees</b-navbar-item>
          </b-navbar-dropdown>
          <b-navbar-dropdown v-if="$store.state.user.role == 'renter'" class="text" label="Tenant">
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'mymaintenance' }">Maintenance Requests</b-navbar-item>
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'addrequest' }">Add Maintenence Request</b-navbar-item>
          </b-navbar-dropdown>
          <b-navbar-dropdown v-if="$store.state.user.role == 'employee'" class="text" label="Employee">
           <b-navbar-item class="text" tag="router-link" :to="{ name: 'mymaintenance' }">Maintenance</b-navbar-item>
          </b-navbar-dropdown>
          <b-navbar-item tag="div">
            <div class="buttons">
              <a v-if="$store.state.token == ''" class="button is-light">
                <router-link class="text" :to="{ name: 'register' }"> Sign up </router-link>
              </a>
              <a  v-if="$store.state.token == ''" class="button is-light">
                <router-link class="text" :to="{ name: 'login' }">Login</router-link>
              </a>
              <a v-if="$store.state.token != ''" class="button is-light">
                <router-link class="text" :to="{ name: 'logout' }">Logout</router-link>
              </a>
            </div>
          </b-navbar-item>
        </template>
      </b-navbar>
    </div>
    

    <router-view />
  </div>
</template>

<style>
html,
body {
  padding-top: 0;
  margin: 0;
  width: 100%;
  height: 100%;
}
#navbar {
  margin: 0;
  padding: 0;
  width: 100%;
}
#registration {
  justify-content: right;
}
#logo {
  width: 125px;
}
.text {
  color: black;
}
#navbar :hover{
  color: black;
}
</style>
