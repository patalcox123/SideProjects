import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    setThumbnail(propertyId, imageId, image){
        return http.put(`/property/${propertyId}/images/${imageId}`, image);
    },
    getImages(propertyId){
        return http.get(`/property/${propertyId}/images`);
    },
    deleteImage(propertyId, imageId){
        return http.delete(`/property/${propertyId}/images/${imageId}`)
    },
    addImage(propertyId, image){
        return http.post(`/property/${propertyId}/images`, image)
    }
  }