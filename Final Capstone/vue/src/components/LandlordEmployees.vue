<template>
  <div id="employees">
    <div id="info">
      <div id="emp" v-for="employee in employees" v-bind:key="employee.employeeId">
        <p><a class="pointer">Employee Id:</a> {{ employee.employeeId }}</p>
        <p><a class="pointer">Employee Name:</a> {{ employee.username }}</p>
        <b-button class="btn" v-on:click="removeEmployee(employee.employeeId)" type="is-primary">
          Remove
        </b-button>
      </div>
    </div>
    <div id="form">
      <form>
        <a class="addemp">Add Employee</a>
        <b-field label="Employee Id">
          <b-input v-model.number="employee.employeeId"></b-input>
        </b-field>

        <div id="buttons">
          <b-button
            class="btn"
            v-on:click.prevent="addEmployee"
            type="submit"
            expanded
            >Submit</b-button
          >
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import employeeService from "@/services/EmployeeService.js";
export default {
  name: "employees",
  data() {
    return {
      employees: [],
      employee: { employeeId: 0 },
    };
  },
  methods: {
    retrieveEmployees() {
      employeeService
        .getEmployees(this.$store.state.user.userId)
        .then((response) => {
          this.employees = response.data;
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.employee.username = "No employee scheduled.";
          }
        });
    },
    removeEmployee(employeeId) {
      this.$buefy.dialog.confirm({
        message: "Are you sure you want to delete this employee?",
        onConfirm: () =>
        {employeeService
          .deleteEmployee(this.$store.state.user.userId, employeeId)

          .then((response) => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Employee successfully deleted");
              this.retrieveEmployees();
            }
          })
          .catch((error) => {
            if (error.response) {
              this.$buefy.dialog.alert(
                `Error deleting Employee. Response received was ${error.response.statusText}`
              );
            }
          });}
      })
        
      
    },
    addEmployee() {
      this.$buefy.dialog.confirm({
        message: "Are you sure you want to add this employee?",
        onConfirm: () => 
        { employeeService
          .addEmployee(this.$store.state.user.userId, this.employee)

          .then((response) => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Employee successfully added");
              this.retrieveEmployees();
            }
          })
          .catch((error) => {
            if (error.response) {
              this.$buefy.dialog.alert(
                `Error adding Employee. Response received was ${error.response.statusText}`
              );
            }
          });}
      })
       
      
    },
  },

  created() {
    this.retrieveEmployees();
  },
};
</script>

<style scoped>
#employees {
  padding-top: 50px;
  padding-left: 15px;
  display: grid;
  max-width: 100%;
  grid-template-columns: 0.6fr 0.4fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "info form";
}
.pointer {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
}
.addemp {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
  text-decoration: underline #031926;
}
#info {
  grid-area: info;
}
#form {
  grid-area: form;
  margin-right: 10px;
}
#info > #emp > .btn {
  background-color: #9dbebb91;
  color: #031926;
  width: 20%;
  font-size: 1vw;
  margin-bottom: 15px;
}

#buttons > .btn {
  background-color: #9dbebb91;
  color: #031926;
  width: 20%;
  font-size: 1vw;
}
#emp {
  font-size: 1vw;
  color: #468189;
  margin-bottom: 15px;
  border-bottom: solid 2px #031926;
  width: 95%;
}
</style>