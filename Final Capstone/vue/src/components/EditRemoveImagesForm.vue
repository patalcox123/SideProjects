<template>
  <div id="editimg">
    <b-field label="Add new Image Link">
      
        <b-input v-model="newImage.link"></b-input>
      </b-field>
      <b-button class="btn" v-on:click="addImage()">Add Image</b-button>
    <div>
      <div class="images" v-for="image in images" v-bind:key="image.imageId">
        <img id="img" v-bind:src="image.link" alt="" />
        <div id="buttons">
          <div><b-button class="btn" id="delete" v-on:click="deleteImage(image.imageId, image.propertyId, image.thumbnail)">Delete Image</b-button></div>
          <div><b-button class="btn" v-on:click="setThumbnail(image.thumbnail, image.propertyId, image.imageId, image.link)">Set as Thumbnail</b-button></div>
        </div>
      </div>
      <b-button class="btn"
          tag="router-link" :to="{ name: 'landlordproperty'}"
          type="submit"
          expanded
          >Cancel</b-button
        >
    </div>
  </div>
</template>

<script>
import imageService from '@/services/ImageService.js'

export default {
  name: "EditRemoveImages",
  data() {
    return {
      images: [],
      image: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: false,
      },
      newImage: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: false,
      }
    };
  },
  methods: {
    retrieveImages() {
      imageService.getImages(this.$route.params.propertyId)
      .then(response => {
        this.images = response.data
        
      })
      
    },
    setThumbnail(thumbnail, propertyId, imageId, link){
      this.image.imageId = imageId;
      this.image.propertyId = propertyId;
      this.image.link = link;
      this.image.thumbnail = thumbnail;
      if (thumbnail) {
        return this.$buefy.dialog.alert("This is already set as your thumbnail.")
      }
      imageService.setThumbnail(propertyId, imageId, this.image)
      .then(response => {
        if (response.status === 200) {
          this.$buefy.dialog.alert("You successfully updated your thumbnail!");
          this.retrieveImages();
        }
      }
      )
      .catch(error => {
        if (error.response) {
          this.$buefy.dialog.alert("There was an issue updating your thumbnail");
        }
        
      })

    },
    deleteImage(imageId, propertyId, thumbnail){
      if (thumbnail) {
        return this.$buefy.dialog.alert("You must set another thumbnail before deleting this image")
      }
      this.$buefy.dialog.confirm({
        message: 'Are you sure you want to delete this image?',
        onConfirm: () => imageService.deleteImage(propertyId, imageId)
          .then((response) => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Image successfully deleted");
              this.retrieveImages();
            }
          })
          .catch((error) => {
            if (error.response) {
              this.$buefy.dialog.alert(
                `Error deleting Image. Response received was ${error.response.statusText}`
              );
            }
          })
      })
        
      
    },
    addImage(){
      this.newImage.propertyId = Number(this.$route.params.propertyId);
      if (this.newImage.link == "") {
        return this.$buefy.dialog.alert("Enter a link for an image")
      }
      imageService.addImage(this.$route.params.propertyId, this.newImage)
      .then(response => {
        if (response.status === 200) {
          this.$buefy.dialog.alert("You successfully added an image!")
          this.retrieveImages();
          this.newImage.link = "";
        }
      }
      )
      .catch(error => {
        if (error.response) {
          this.$buefy.dialog.alert("There was an issue adding your image")
        }
        
      })
    }
  },
  created() {
    this.retrieveImages();
  },
};
</script>

<style scoped>
#editimg {
  padding-top: 50px;
  padding-left: 10px;
}
.btn {
  background-color: #9dbebb91;
  color: #031926;
  width: 200px;
  height: 50px;
}
#delete {
  margin-bottom: 10px;
}
.images {
  display: grid;
  grid-template-columns: .8fr .2fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "img btns";
  border-bottom: solid 3px #031926;
  margin-bottom: 15px;
  padding-bottom: 15px;
}
#img {
  grid-area: img;
}
#guttons {
  grid-area: btns;
}
</style>