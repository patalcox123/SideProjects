import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    getApplications(id){
        return http.get(`/application/${id}`);
    },
    addApplication(app) {
        return http.post('/application', app)
    },
    approveApplication(app) {
        return http.put(`/application/${app.applicationId}/approve`, app)
    },
    rejectApplication(appId) {
        return http.put(`/application/${appId}/reject`)
    }
}