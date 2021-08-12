import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    
    getProperties(){
        return http.get('/property');
    },

    getProperty(propertyId){
        return http.get(`/property/${propertyId}`);
    },

    addProperty(property) {
        return http.post('/property', property)
    },
    deleteProperty(propertyId){
        return http.delete(`/property/${propertyId}`)
    },
    updateProperty(propertyId, property){
        return http.put(`/property/${propertyId}`, property)
    },

    getPropertyByRenterId(renterId){
        return http.get(`/property/renter/${renterId}`)
    }

}