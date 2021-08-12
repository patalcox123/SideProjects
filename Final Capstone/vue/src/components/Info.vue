<template>
  <div id="info">
    <div class="desc">
    <h1 class="title">My Profile</h1>
    <p><a class="pointer">My Id: </a> {{this.$store.state.user.userId}}</p>
    <p><a class="pointer">My Username: </a> {{this.$store.state.user.username}}</p>
    <p><a class="pointer">My Role: </a> {{this.$store.state.user.role}}</p>
    <p v-if="$store.state.user.role == 'renter'" ><a class="pointer">My Property: </a> {{this.prop}}</p>
    </div>
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";

export default {
 data(){
   return{
     prop: ''
   }
 },
 methods: {
    retrieveProperty() {
      propertyService
        .getPropertyByRenterId(this.$store.state.user.userId)
        .then((response) => {
          this.prop = response.data.addressLineOne;
          console.log(this.prop);
        })
        .catch((error) => {
          if (error) {
            this.prop = 'No Property'
          }
        });
    },
  },
  created() {
    this.retrieveProperty();
  },
};
</script>

<style scoped>
#info{
    display: grid; 
    text-align: center;
  grid-template-columns: 1fr 1fr 1fr; 
  grid-template-rows: 1fr; 
  gap: 0px 0px; 
  grid-template-areas: 
    ". info .";
    padding-top: 50px;
}
.pointer {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
}
.desc {
  font-size: 1vw;
  color: #468189;
  grid-area: info;
}
.title {
  color: #468189;
  font-size: 2vw;
  text-align: center;
  text-decoration: underline #031926;
}
</style>