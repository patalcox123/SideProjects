<template>
  <div id="task">
    <div id="info">
      <p v-if="task.isUrgent"><a class="urgent">Urgent!</a></p>
      <p><a class="pointer">Task Id:</a> {{ task.taskId }}</p>
      <p><a class="pointer">Employee Name:</a> {{ employee.username }}</p>
      <p><a class="pointer">Property Id:</a> {{ task.propertyId }}</p>
      <p><a class="pointer">Task Description:</a> {{ task.taskDescription }}</p>
      <p><a class="pointer">Date Entered:</a> {{ task.dateEntered }}</p>
      <p><a class="pointer">Date Scheduled:</a> {{ task.dateScheduled }}</p>
      <p><a class="pointer">Task Status:</a> {{ task.taskStatus }}</p>
    </div>
      <b-button class="btn" v-if="this.$store.state.user.role == 'landlord' && task.taskStatus != 'Completed'" tag="router-link" :to="{ name: 'editrequest' }" type="is-primary">
            Edit Request
        </b-button>
        <b-button class="btn" v-on:click="updateTask" v-if="this.$store.state.user.role == 'employee' && task.taskStatus == 'Scheduled'"  type="is-primary">
            Move Task to Completed
        </b-button>
         <b-button  class="btn" tag="router-link" :to="{ name: 'mymaintenance' }" type="is-primary">
            Back
        </b-button>
  </div>
</template>

<script>
import taskService from "@/services/TaskService.js";
import employeeService from "@/services/EmployeeService.js";

export default {
  name: "landlord-task",
  data() {
    return {
      task: {},
      employee: {},

    }
  },
  methods: {
    retrieveTask() {
      taskService
        .getTask(this.$route.params.taskId)
        .then((response) => {
          this.$store.commit("SET_TASK", response.data);
          this.task = this.$store.state.task;
          this.retrieveEmployee();
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert(
              "The task is not available. It may have been deleted or you have entered an invalid Id."
            );
            this.$router.push("/myMaintenance");
          }
        });
    },
    retrieveEmployee() {
      employeeService
        .getEmployee(this.$store.state.user.userId, this.$store.state.task.employeeId)
        .then((response) => {
          this.employee = response.data;
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.employee.username = "No employee scheduled."
          }
        });
    },
    updateTask(){
      console.log(this.task)  
      this.$buefy.dialog.confirm({
        message: "Are you sure you want to update?",
        onConfirm: () =>
        {this.task.taskStatus = 'Completed';
        taskService.updateTaskStatus(this.task)
        .then(response => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Property successfully updated");
              this.$router.push("/myMaintenance");
            }
          })
          .catch(error => {
            if (error.response) {
              this.$buefy.dialog.alert(`Error updating task. Response received was ${error.response.statusText}`)
            }
          });}
      })
        
      
      
    }
   
},
// computed: {
//     task() {
//       return this.$store.state.task;
//     }
// },
created() {
    this.retrieveTask();
    //this.retrieveEmployee();
},
}
</script>

<style scoped>
#task {
  padding-top: 50px;
  padding-left: 10px;
}
#task > .btn {
  background-color: #9dbebb91;
  color: #031926;
  margin-right: 15px;
  width: 20%;
  font-size: 1vw;
}
#info {
  font-size: 1vw;
  color: #468189;
  margin-bottom: 15px;
}
.pointer {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
}
.urgent {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
  font-weight: bolder;
  text-decoration: underline #031926;
}
</style>