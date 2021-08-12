<template>
<div>
    <div class="biggrid">
      <div class="container" id="search">
        <img id="logo" src="../assets/images/logo.jpg" alt="logo" />
        <div id="searchbar">
          <div class="searchinputs">
            <b-field class="inputs">
              <b-input placeholder="City" v-model="filter.city" rounded></b-input>
            </b-field>
            <b-field class="inputs">
              <b-select v-model="filter.state" rounded expanded>
                <option value="State">State</option>
                <option value="AL">AL</option>
                <option value="AK">AK</option>
                <option value="AZ">AZ</option>
                <option value="AR">AR</option>
                <option value="CA">CA</option>
                <option value="CO">CO</option>
                <option value="CT">CT</option>
                <option value="DE">DE</option>
                <option value="DC">DC</option>
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
              </b-select>
            </b-field>
            <b-field class="inputs">
              <b-input v-model="filter.zipCode" placeholder="Zip" rounded></b-input>
            </b-field>
          </div>
          <div class="checkboxes">
            <div id="beds">
              <div class="block">
                Beds
                <b-checkbox type="is-black" v-model="bedGroup"
                    native-value="1">
                    1
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bedGroup"
                    native-value="2">
                    2
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bedGroup"
                    native-value="3">
                    3
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bedGroup"
                    native-value="4">
                    4+
                </b-checkbox>
              </div>
            </div>
            <div id="baths">
              <div class="block">
                Baths
                <b-checkbox type="is-black" v-model="bathGroup"
                    native-value="1">
                    1
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bathGroup"
                    native-value="1.5">
                    1.5
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bathGroup"
                    native-value="2">
                    2
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bathGroup"
                    native-value="2.5">
                    2.5
                </b-checkbox>
                <b-checkbox type="is-black" v-model="bathGroup"
                    native-value="3">
                    3+
                </b-checkbox>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="results">
        <div v-for="prop in filteredProperties" v-bind:key="prop.propertyId" >
            <router-link v-bind:to="{name: 'Card', params: {propertyId: prop.propertyId}}">
            <div class="displaygrid">
              <img class="thumbnail" v-bind:src="prop.thumbnail" alt="Property Thumbnail Image" />
              <div class="information">
                <h1 id="address">{{ prop.addressLineOne }} {{ prop.addressLineTwo }} {{ prop.city }}, {{ prop.state }} {{ prop.zipCode }}</h1>
                <div id="description">
                  {{ prop.description }}
                </div>
                <b-button id="contact" label="Email Property"  type="is-dark" size="is-medium" @click="prompt" />
              </div>
            </div>
        </router-link>
        </div>
        </div>
    </div>
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
          filter: {
            addressLineOne: "",
            city: "",
            state: "State",
            zipCode: "",
            beds: "",
            baths: ""
          },
          bathGroup: [],
          bedGroup: [],
          properties: [],
       }
   },
    
    methods: {
        retrieveProperties(){
            propertyService.getProperties()
            .then(response => {
                this.properties = response.data
            })
            .catch(error => {
                if (error.response && error.response.status === 404) {
                    this.$buefy.dialog.alert("Properties not found")
                }
                this.$router.push("/")
                
            }
            )
        },
        prompt() {
            this.$buefy.dialog.prompt({
                message: `Message`,
                inputAttrs: {
                    placeholder: 'e.g. Hi, I am interested in this apartment for sale.',
                    maxlength: 300
                },
                trapFocus: true,
                onConfirm: () => this.$buefy.toast.open(`Your email has been sent. Thank You!`)
            })
        },
    },
    computed: {
        filteredProperties(){
            let filteredProperties = this.properties;
            let bathCount = this.bathGroup.filter((num) => {
              if(num != ""){
                return num.toString();
              }
              else{
                return "";
              }
            });
            let finalBath = bathCount.toString();
            let bedCount = this.bedGroup.filter((num) => {
              if(num != ""){
                return num.toString();
              }
              else{
                return "";
              }
            });
            let finalBed = bedCount.toString();
            console.log(finalBath);
            if (this.filter.city != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.city.toLowerCase().includes(this.filter.city.toLowerCase())
                );
            }
            if (this.filter.state != "State") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.state.toUpperCase().includes(this.filter.state.toUpperCase())
                );
            }
            if (this.filter.zipCode != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.zipCode.includes(this.filter.zipCode)
                );
            }
            if (finalBed != "" && finalBed != 4) {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.beds == finalBed);
            }
             if (finalBed == 4) {
                filteredProperties = filteredProperties.filter((prop) =>
                    parseInt(prop.beds.toString()) >= parseInt(finalBed.toString()));
            }
            if (finalBath != "" &&  finalBath != 3) {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.baths == finalBath);
            }
            if (finalBath == 3) {
                filteredProperties = filteredProperties.filter((prop) =>
                    parseInt(prop.baths.toString()) >= parseInt(finalBath.toString()));
            }
            return filteredProperties;
        }
    },
    created(){
        this.retrieveProperties();
    }
}
</script>

<style scoped>
#plantimage {
  height: auto;
  width: 100%;
}
#search {
  text-align: center;
  height: auto;
  max-width: 100%;
  width: 100%;
}
#searchbar {
  grid-area: search;
  padding-top: 50px;
  padding-left: 50px;
  max-width: 65%;
}
#logo {
  grid-area: img;
  height: 80%;
  width: auto;
  padding-left: 100px;
}
.inputs {
  padding-bottom: 25px;
}
#baths {
  background-color: white;
  padding-top: 6px;
  margin-bottom: 37px;
  height: 18%;
  width: 65%;
  border-radius: 25px;
}
#beds {
  background-color: white;
  padding-top: 6px;
  height: 18%;
  width: 65%;
  border-radius: 25px;
  margin-bottom: 37px;
}
.container {
  align-items: center;
  display: grid;
  max-width: 100%;
  grid-template-columns: 1fr 1fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "img search";
  column-gap: 75px;
  background-image: url("../assets/images/background.jpg");
  background-size: 100%;
}
.biggrid {
 display: grid; 
  grid-template-columns: 1fr; 
  grid-template-rows: .20fr .80fr; 
  gap: 0px 0px; 
  grid-template-areas: 
    "search" 
    "results";
  grid-row-gap: 50px;
}
.thumbnail {
  width: 300px;
  height: 250px;
}
.displaygrid {
  display: grid;
  grid-template-columns: .2fr .75fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "thumbnail information";
  border-bottom: solid 3px #031926;
  margin-bottom: 15px;
  padding-bottom: 15px;
}
#address {
  color: #468189;
  font-size: 2vw;
}
#description {
  color: #468189;
  font-size: 1vw;
  padding-bottom: 15px;
}
#contact {
  background-color: #9dbebb91;
  color: #031926;
}
::placeholder {
  color: black IM !important;
  opacity: 2 IM !important;
}
.results {
  grid-area: results;
  padding-left: 70px;
}
</style>