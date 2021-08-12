<template>
  <div id="card" class="container">
    <div class="slideshow">
      <b-carousel :autoplay="false" :indicator-inside="false">
        <b-carousel-item v-for="image in property.images" :key="image.imageId">
          <b-image class="image" :src="image.link"></b-image>
        </b-carousel-item>
        <!-- <template #indicators="props">
            <b-image class="al image" :src="props.i" :title="props.i"></b-image>
        </template> -->
      </b-carousel>
      <!-- <img v-bind:src="image.link" alt="Property Image" /> -->
    </div>
    <div class="info details">
      <h2 id="address" class="address">
        {{ property.addressLineOne }}
        {{ property.addressLineTwo }}
        {{ property.city }},
        {{ property.state }}
        {{ property.zipCode }}
      </h2>
      <div class="specifics">
        <p id="beds">
          Beds:
          {{ property.beds }}
        </p>
        <p id="baths">
          Baths:
          {{ property.baths }}
        </p>
        <p id="cost">
          Cost per month:
          {{ property.price }}
        </p>
        <p id="date">
          Date available:
          {{ property.dateAvailable }}
        </p>
        <p id="description">
          {{ property.description }}
        </p>
        <form v-if="$store.state.user.role == 'renter'">
          <h1 id="appheader" class="application">Application to Rent</h1>
          <b-field class="application" label="Name">
            <b-input v-model="application.name"></b-input>
          </b-field>
          <b-field class="application" label="Email Address">
            <b-input v-model="application.email"></b-input>
          </b-field>
          <b-field class="application" label="Number of Tenants">
            <b-input v-model.number="application.tenants"></b-input>
          </b-field>
          <b-field class="application" label="Requested Move in Date">
            <b-input type="date" v-model="application.moveInDate"></b-input>
          </b-field>
          <b-field class="application" label="Monthly Income">
            <b-input v-model.number="application.income"></b-input>
          </b-field>
          <div>
            <b-button id="submit" v-on:click.prevent="addApp" type="submit" expanded>Submit</b-button>
            <b-button tag="router-link" id="bk" :to="{ name: 'home' }" type="is-primary" expanded>Back</b-button>
          </div>
        </form>
        <div v-if="$store.state.user.role == 'landlord'" id="options">
          <b-button tag="router-link" id="back" :to="{ name: 'myproperties' }" type="is-primary">Back</b-button>
          <b-dropdown id="drpdwn" aria-role="list">
            <template #trigger="{ active }">
                <b-button id="actions"
                    label="Property Actions"
                    type="is-primary"
                    :icon-right="active ? 'menu-up' : 'menu-down'" />
            </template>
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'editproperty' }">Edit Property</b-navbar-item>
            <b-navbar-item class="text" v-on:click="deleteProperty">Delete Property</b-navbar-item>
            <b-navbar-item class="text" tag="router-link" :to="{ name: 'editimages' }">Edit/Remove Images</b-navbar-item>
          </b-dropdown>
        </div>
        <div v-if="$store.state.user.role == undefined" id="login">
          <div>
              <a id="btnsignup" v-if="$store.state.token == ''" class="button">
                <router-link class="text" :to="{ name: 'register' }"> Sign up </router-link>
              </a>
              <a  id="btnlogin" v-if="$store.state.token == ''" class="button">
                <router-link class="text" :to="{ name: 'login' }">Login</router-link>
              </a>
          </div>
        </div>
      </div>
      <div class="contact">
        <img src="../assets/images/homepage.jpg" />
      </div>
    </div>
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";
import appService from "@/services/AppService.js";

export default {
  name: "property-detail",
  props: ["prop"],
  data() {
    return {
       application: {
        applicationId: 0,
        renterId: 0,
        landlordId: 0,
        propertyId: 0,
        name: "",
        email: "",
        tenants: 0,
        moveInDate: "",
        income: 0,
        status: "Pending",
      }
    }
  },
  methods: {
    retrieveProperty() {
      propertyService
        .getProperty(this.$route.params.propertyId)
        .then((response) => {
          console.log(this.$store.state.user.userId)
          this.$store.commit("SET_PROPERTY", response.data);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert(
              "The property is not available. It may have been deleted or you have entered an invalid Id."
            );
            this.$router.push("/");
          }
        });
    },
    addApp(){
      this.application.renterId = this.$store.state.user.userId;
      this.application.propertyId = this.$store.state.property.propertyId;
      appService.addApplication(this.application)
      .then(response => {
        if (response.status === 200) {
          this.$buefy.dialog.alert("You successfully applied!")
          this.$router.push({name: 'home'})
        }
      }
      )
      .catch(error => {
        if (error.response) {
          this.$buefy.dialog.alert("There was an issue with your application.")
        }
        
      })
    },
    deleteProperty() {
      this.$buefy.dialog.confirm({
        message: "Are you sure you want to delete this property?",
        onConfirm: () =>
        { propertyService
          .deleteProperty(this.$route.params.propertyId)
          .then((response) => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Property successfully deleted");
              this.$router.push("/myProperties");
            }
          })
          .catch((error) => {
            if (error.response) {
              this.$buefy.dialog.alert(
                `Error deleting property. Response received was ${error.response.statusText}`
              );
            }
          });}
      }) 
       
      
    },
  },
  created() {
    this.retrieveProperty();
  },
  computed: {
    property() {
      return this.$store.state.property;
    },
  },
};
</script>

<style scoped>
#card {
  padding-top: 50px;
  padding-left: 10px;
  max-width: 100%;
}
.container {
  display: grid;
  grid-template-columns: 0.4fr 0.6fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "slideshow info";
}
.info {
  grid-area: info;
}
.image {
  width: auto;
}
.slideshow {
  padding-right: 15px;
  grid-area: slideshow;
}
.details {
  display: grid;
  grid-template-columns: 0.4fr 0.6fr;
  grid-template-rows: 0.1fr 0.9fr;
  grid-template-areas:
    "address address"
    "specifics contact";
}
#address {
  color: #468189;
  font-size: 2vw;
  border-bottom: solid 2px #031926;
  grid-area: address;
  margin-bottom: 15px;
}
.specifics {
  grid-area: specifics;
}
.contact {
  grid-area: contact;
  height: 750px;
  background-size: cover;
}
#description {
  padding-top: 10px;
  padding-right: 25px;
  color: #468189;
}
#beds {
  color: #468189;
  font-size: 1vw;
}
#baths {
  color: #468189;
  font-size: 1vw;
}
#cost {
  color: #468189;
  font-size: 1vw;
}
#date {
  color: #468189;
  font-size: 1vw;
}
.application {
  width: 75%;
  color: #468189;
}
#appheader {
  border-bottom: solid 1px #031926;
  padding-top: 15px;
  font-size: 1vw;
}
.application > .label {
  color: #468189;
}
.is-active .al img {
  filter: grayscale(0%);
}
.al img {
  filter: grayscale(100%);
}
#actions {
  background-color: #9dbebb91;
  color: #031926;
}
#options {
  padding-top: 25px;
}
#drpdwn :hover{
  color: black;
}
#back {
  background-color: #9dbebb91;
  color: #031926;
  max-width: 35%;
  margin-right: 10px;
}
#bk{
  background-color: #9dbebb91;
  color: #031926;
  max-width: 50%;
}
#submit {
  background-color: #9dbebb91;
  color: #031926;
  max-width: 50%;
  margin-bottom: 10px;
}
#btnsignup {
  background-color: #9dbebb91;
  color: #031926;
  margin-right: 15px;
  margin-top: 10px;
}
#btnlogin {
  background-color: #9dbebb91;
  color: #031926;
  margin-right: 15px;
  margin-top: 10px;
}
</style>