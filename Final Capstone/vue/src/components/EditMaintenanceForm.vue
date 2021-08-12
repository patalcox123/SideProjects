<template>
  <div id="editform">
    <form>
      <b-field  label="Employee">
        <b-select placeholder="Select an employee" v-model="task.employeeId">
          <optgroup>
            <option v-for="employee in employees" v-bind:key="employee.employeeId" 
            v-bind:value="employee.employeeId"> 
                {{ employee.username }}
            </option>
          </optgroup>
        </b-select>
      </b-field>

      <b-field label="Date Scheduled">
        <b-input type="date" v-model="task.dateScheduled"></b-input>
      </b-field>

      <b-field label="Description">
        <b-input
          maxlength="200"
          type="textarea"
          v-model="task.taskDescription"
        ></b-input>
      </b-field>

      <div id="buttons">
        <b-button class="btn"
          v-on:click.prevent="updateTask"
          type="submit"
          expanded
          >Submit</b-button
        >
        <b-button class="btn"
          tag="router-link" :to="{ name: 'landlord-task', params: {taskId: task.taskId}}"
          type="submit"
          expanded
          >Cancel</b-button
        >
      </div>
    </form>
  </div>
</template>

<script>
import taskService from "@/services/TaskService.js";
import employeeService from "@/services/EmployeeService.js";

export default {
  data() {
    return {
      task: {
      taskId: 0,
      employeeId: 0,
      propertyId: 0,
      isUrgent: false,
      taskDescription: "",
      dateEntered: "",
      dateScheduled: "",
      taskStatus: ""
    },
    employees: []
    };
  },
  methods: {
    retrieveTask() {
      taskService
        .getTask(this.$route.params.taskId)
        .then((response) => {
          this.$store.commit("SET_TASK", response.data);
          this.task = this.$store.state.task;
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert(
              "The task is not available. It may have been deleted or you have entered an invalid Id."
            );
            this.$router.push({ name: 'landlord-task', params: {taskId: this.task.taskId}});
          }
        }); 
    },
    retrieveEmployees() {
      employeeService
        .getEmployees(this.$store.state.user.userId)
        .then((response) => {
          this.employees = response.data;
          console.log(this.employees);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert("Employees not found");
          }
          this.$router.push("/");
        });
    },
    updateTask(){
        console.log(this.task);
      if (confirm("Are you sure you want to update?")) {
        this.task.taskStatus = 'Scheduled';
        taskService.updateTask(this.task)
        .then(response => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Task successfully updated");
              this.$router.push("/myMaintenance");
            }
          })
          .catch(error => {
            if (error.response) {
              this.$buefy.dialog.alert(`Error updating task. Response received was ${error.response.statusText}`)
            }
          });
      }
      
    }
  },
  created(){
    this.retrieveTask();
    this.retrieveEmployees();
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