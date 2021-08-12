import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    
    getEmployees(landlordId){
        return http.get(`/employee/${landlordId}/employees`);
    },
    getEmployee(landlordId, employeeId){
        return http.get(`/employee/${landlordId}/employee/${employeeId}`);
    },
    addEmployee(landlordId,employee){
        return http.post(`/employee/${landlordId}/newemployee`, employee)
    },
    deleteEmployee(landlordId,employeeId){
        return http.delete(`/employee/${landlordId}/employee/${employeeId}`)
    }
    

}