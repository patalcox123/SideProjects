<template>
  <div id="employee">
      <div id="scheduled">
        <h1 class="title">Scheduled</h1>
        <div class="info" v-for="task in scheduledTasks" v-bind:key="task.taskId">
             <router-link v-bind:to="{ name: 'landlord-task', params: {taskId: task.taskId}}">
            <div class="desc">
              <p v-if="task.isUrgent"><a class="urgent">Urgent</a></p>
                <p><a class="pointer">Address:</a> {{task.addressLineOne}} {{task.addressLineTwo}} {{task.city}}, {{task.state}} {{task.zipCode}}</p>
                <p><a class="pointer">Date Scheduled:</a> {{task.dateScheduled}}</p>
                </div>
                <div class="desc">
                  <a class="pointer">Notes:</a> {{task.taskDescription}}
                </div>
             </router-link>
          </div>
      </div>
      <div id="completed">
        <h1 class="title">Completed</h1>
        <div class="info" v-for="task in completedTasks" v-bind:key="task.taskId">
             <router-link v-bind:to="{ name: 'landlord-task', params: {taskId: task.taskId}}">
            <div class="desc">
              <p v-if="task.isUrgent"><a class="urgent">Urgent</a></p>
                <p><a class="pointer">Address:</a> {{task.addressLineOne}} {{task.addressLineTwo}} {{task.city}}, {{task.state}} {{task.zipCode}}</p>
                </div>
                <div class="desc">
                  <a class="pointer">Notes:</a> {{task.taskDescription}}
                </div>
             </router-link>
          </div>
      </div>
  </div>
</template>

<script>
import taskService from "@/services/TaskService.js";


export default {
    name: "maintance-landlord",
    data() {
      return {
        filteredTasks: [],
        pendingTasks: [],
        scheduledTasks: [],
        completedTasks: [],
        employees: []
      };
  },

  methods: {
    retrieveTasks() {
      taskService
        .getTasks()
        .then((response) => {
          this.filteredTasks = response.data.filter((task) => task.employeeId == this.$store.state.user.userId)
          this.filterTasks(this.filteredTasks);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert("Tasks not found");
          }
          this.$router.push("/");
        })
    },
    filterTasks(tasks) {
      console.log(tasks)
      this.pendingTasks = tasks.filter(
            (task) => task.taskStatus == "Pending"
          );
      this.scheduledTasks = tasks.filter(
            (task) => task.taskStatus == 'Scheduled'
          );
      this.completedTasks = tasks.filter(
            (task) => task.taskStatus == 'Completed'
          );
    },
    
  },
  computed: {
    tasks() {
      return this.$store.state.tasks;
    }
  },
  created() {
    this.retrieveTasks();
    
    //this.retrieveEmployees();
  },
}

</script>

<style scoped>
#employee {
  padding-top: 50px;
  display: grid; 
  grid-template-columns: 1fr 1fr; 
  grid-template-rows: 1fr; 
  gap: 0px 0px; 
  grid-template-areas: 
    "scheduled completed";
}
#scheduled {
  grid-area: scheduled;
  border-right: solid 4px #031926;
}
#completed {
  grid-area: completed;
}
.title {
  color: #468189;
  font-size: 2vw;
  text-align: center;
  text-decoration: underline #031926;
}
.desc {
  font-size: 1vw;
  color: #468189;
}
.pointer {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
}
.info {
  margin-left: 15px;
  border-bottom: solid 1px #031926;
  width: 75%;
  padding-bottom: 5px;
  margin-bottom: 5px;
}
.urgent {
  font-size: 1.2vw;
  color: #2f565c;
  font-style: italic;
  font-weight: bolder;
}
</style>