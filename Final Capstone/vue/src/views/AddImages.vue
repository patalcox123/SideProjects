<template>
  <div>
    <form>
      <b-field v-show="this.$store.state.showButton" label="Add Thumbnail">
        <b-input v-model="imageThumbnail.link"></b-input>
      </b-field>
      <b-field v-show="!this.$store.state.showButton" label="Add Image">
        <b-input v-model="image.link"></b-input>
      </b-field>
      <b-button v-on:click.prevent="addImage"   type="is-primary" style="background-color:powderblue">Add</b-button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      imageThumbnail: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: true
      },
      image: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: false
      },
    };
  },
  methods: {
      addImage(){
        if(this.$store.state.showButton == true) {
          this.$store.commit("ADD_PROPERTIES_IMAGE", this.imageThumbnail);
          this.$store.commit("SET_THUMBNAIL", this.imageThumbnail.link);
          this.$router.push({name: 'addproperty'});
      }
        else{
          this.$store.commit("ADD_PROPERTIES_IMAGE", this.image);
          this.$router.push({name: 'addproperty'});
      }
      }
  }
};
</script>

<style>
</style>