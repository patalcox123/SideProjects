<template>
  <div id="editform">
    <form>
      <b-field label="Street Address">
        <b-input v-model="property.addressLineOne"></b-input>
      </b-field>

      <b-field label="Address Line 2 (Optional)">
        <b-input v-model="property.addressLineTwo"> </b-input>
      </b-field>
      <b-field label="City">
        <b-input v-model="property.city"></b-input>
      </b-field>
      <b-field  label="State">
        <b-select v-model="property.state" placeholder="Select a state" icon="account">
          <optgroup>
            <option value="AL">AL</option>
            <option value="AK">AK</option>
            <option value="AZ">AZ</option>
            <option value="AR">AR</option>
            <option value="CA">CA</option>
            <option value="CO">CO</option>
            <option value="CT">CT</option>
            <option value="DE">DE</option>
            <option value="FL">FL</option>
            <option value="GA">GA</option>
            <option value="HI">HI</option>
            <option value="ID">ID</option>
            <option value="IL">IL</option>
            <option value="IN">IN</option>
            <option value="IA">IA</option>
            <option value="KS">KS</option>
            <option value="KY">KY</option>
            <option value="LA">LA</option>
            <option value="ME">ME</option>
            <option value="MD">MD</option>
            <option value="MA">MA</option>
            <option value="MI">MI</option>
            <option value="MN">MN</option>
            <option value="MS">MS</option>
            <option value="MO">MO</option>
            <option value="MT">MT</option>
            <option value="NE">NE</option>
            <option value="NV">NV</option>
            <option value="NH">NH</option>
            <option value="NJ">NJ</option>
            <option value="NM">NM</option>
            <option value="NY">NY</option>
            <option value="NC">NC</option>
            <option value="ND">ND</option>
            <option value="OH">OH</option>
            <option value="OK">OK</option>
            <option value="OR">OR</option>
            <option value="PA">PA</option>
            <option value="RI">RI</option>
            <option value="SC">SC</option>
            <option value="SD">SD</option>
            <option value="TN">TN</option>
            <option value="TX">TX</option>
            <option value="UT">UT</option>
            <option value="VT">VT</option>
            <option value="VA">VA</option>
            <option value="WA">WA</option>
            <option value="WV">WV</option>
            <option value="WI">WI</option>
            <option value="WY">WY</option>
          </optgroup>
        </b-select>
      </b-field>
      <b-field label="Zip Code">
        <b-input maxlength="5" v-model="property.zipCode"></b-input>
      </b-field>
      <b-field label="Beds">
        <b-input v-model.number="property.beds"></b-input>
      </b-field>

      <b-field label="Baths">
        <b-input v-model.number="property.baths"> </b-input>
      </b-field>
      <b-field label="Price">
        <b-input v-model.number="property.price"></b-input>
      </b-field>
      <b-field label="Date Available">
        <b-input type="date" v-model="property.dateAvailable"></b-input>
      </b-field>

      <b-field label="Description">
        <b-input
          maxlength="200"
          type="textarea"
          v-model="property.description"
        ></b-input>
      </b-field>
      <div id="buttons">
        <b-button class="btn"
          v-on:click.prevent="updateProperty"
          type="submit"
          expanded
          >Submit</b-button
        >
        <b-button class="btn"
          tag="router-link" :to="{ name: 'landlordproperty'}"
          type="submit"
          expanded
          >Cancel</b-button
        >
      </div>
    </form>
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";

export default {
  data() {
    return {
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
        available: true,
        beds: 0,
        baths: 0,
        images: [],
        thumbnail: "",
      },
    };
  },
  methods: {
    retrieveProperty() {
      propertyService
        .getProperty(this.$route.params.propertyId)
        .then((response) => {
          this.$store.commit("SET_PROPERTY", response.data);
          this.property = response.data;
          
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert(
              "The property is not available. It may have been deleted or you have entered an invalid Id."
            );
            this.$router.push({name: 'landlordproperty'});
          }
        });
        
    },
    updateProperty(){
     this.$buefy.dialog.confirm({
       message: 'Are you sure you want to update?',
       onConfirm: () => propertyService.updateProperty(this.$route.params.propertyId, this.property)
        .then(response => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Property successfully updated");
              this.$router.push("/myProperties");
            }
          })
          .catch(error => {
            if (error.response) {
              this.$buefy.dialog.alert(`Error updating property. Response received was ${error.response.statusText}`)
            }
          })
     }
       )
        
      
      
    }
  },
  created(){
    this.retrieveProperty();
  }
};
</script>

<style scoped>
#editform {
  padding-top: 50px;
}
#buttons > .btn {
  background-color: #9dbebb91;
  color: #031926;
}
</style>