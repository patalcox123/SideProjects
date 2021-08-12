<template>
  <div id="myprops">
    <div v-for="prop in properties" v-bind:key="prop.propertyId">
      <router-link
        v-bind:to="{
          name: 'landlordproperty',
          params: { propertyId: prop.propertyId },
        }"
      >
        <div class="props">
          <img class="img" v-bind:src="prop.thumbnail" alt="Property Thumbnail Image" />
          <div class="info">
            <h1 id="address">{{ prop.addressLineOne }} {{ prop.addressLineTwo }} {{ prop.city }}, {{ prop.state }} {{ prop.zipCode }}</h1>
            <div id="description">
              {{ prop.description }}
            </div>
          </div>
        </div>
      </router-link>
    </div>
    <b-button id="addpropbtn" tag="router-link" :to="{ name: 'addproperty' }" type="is-primary"
      >Add a New Property</b-button
    >
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";
//import propertyCard from '@/components/PropertyCard.vue'

export default {
  name: "properties-list",
  // components: {
  //   propertyCard

  //},
  data() {
    return {
      properties: [],
    };
  },

  methods: {
    retrieveProperties() {
      propertyService
        .getProperties()
        .then((response) => {
          this.properties = response.data;

          
          this.properties = this.properties.filter(
            (property) => property.landlordId == this.$store.state.user.userId
          );
          console.log(this.properties);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert("Properties not found");
          }
          this.$router.push("/");
        });
    },
  },
  created() {
    this.retrieveProperties();
  },
};
</script>

<style scoped>
#myprops{
  padding-top: 50px;
  padding-left: 10px;
}
.props {
  display: grid;
  grid-template-columns: .3fr .7fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "img info";
  border-bottom: solid 3px #031926;
  margin-bottom: 15px;
  padding-bottom: 15px;
}
.img {
  grid-area: img;
}
.info {
  grid-area: info;
}
#address {
  color: #468189;
  font-size: 3vw;
}
#description {
  color: #468189;
  font-size: 1.5vw;
  padding-bottom: 15px;
}
#addpropbtn {
   background-color: #9dbebb91;
  color: #031926;
}
</style>

