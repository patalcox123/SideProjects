<template>
  <div id="landlord">
    <div id="pending">
      <h1 class="title">Pending</h1>
      <div
        id="pend"
        class="info"
        v-for="app in pendingApps"
        v-bind:key="app.applicationId"
      >
        <div class="desc">
          <p><a class="pointer">Address:</a> {{app.addressLineOne}} {{app.addressLineTwo}} {{app.city}}, {{app.state}} {{app.zipCode}}</p>
          <p><a class="pointer">Name: </a> {{ app.name }}</p>
          <p><a class="pointer">Email: </a> {{ app.email }}</p>
          <p><a class="pointer">Number of Tenants: </a> {{ app.tenants }}</p>
          <p><a class="pointer">Income: </a> {{ app.income }}</p>
          <p>
            <a class="pointer">Requested Move-in Date: </a> {{ app.moveInDate }}
          </p>
        </div>
        <b-button
          class="btn"
          v-on:click="
            approveApp(app.applicationId, app.renterId, app.propertyId)
          "
          type="is-primary"
        >
          Approve
        </b-button>
        <b-button
          class="btn"
          v-on:click="rejectApp(app.applicationId)"
          type="is-primary"
        >
          Reject
        </b-button>
      </div>
    </div>
    <div id="approved">
      <h1 class="title">Approved</h1>
      <div
        class="info"
        v-for="app in approvedApps"
        v-bind:key="app.applicationId"
      >
        <div class="desc">
          <p><a class="pointer">Address:</a> {{app.addressLineOne}} {{app.addressLineTwo}} {{app.city}}, {{app.state}} {{app.zipCode}}</p>
          <p><a class="pointer">Name: </a> {{ app.name }}</p>
          <p><a class="pointer">Email: </a> {{ app.email }}</p>
          <p><a class="pointer">Number of Tenants: </a> {{ app.tenants }}</p>
          <p><a class="pointer">Income: </a> {{ app.income }}</p>
          <p>
            <a class="pointer">Requested Move-in Date: </a> {{ app.moveInDate }}
          </p>
        </div>
      </div>
    </div>
    <div id="rejected">
      <h1 class="title">Rejected</h1>
      <div
        class="info"
        v-for="app in rejectedApps"
        v-bind:key="app.applicationId"
      >
        <div class="desc">
          <p><a class="pointer">Address:</a> {{app.addressLineOne}} {{app.addressLineTwo}} {{app.city}}, {{app.state}} {{app.zipCode}}</p>
          <p><a class="pointer">Name: </a> {{ app.name }}</p>
          <p><a class="pointer">Email: </a> {{ app.email }}</p>
          <p><a class="pointer">Number of Tenants: </a> {{ app.tenants }}</p>
          <p><a class="pointer">Income: </a> {{ app.income }}</p>
          <p>
            <a class="pointer">Requested Move-in Date: </a> {{ app.moveInDate }}
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import appService from "@/services/AppService.js";


export default {
    name: "applications-landlord",
    data() {
      return {
        filteredApps: [],
        pendingApps: [],
        approvedApps: [],
        rejectedApps: [],
        app: {
          applicationId: 0,
          renterId: 0,
          propertyId: 0,
          status: ""
        }
      };
  },

  methods: {
    retrieveApps() {
      appService
        .getApplications(this.$store.state.user.userId)
        .then((response) => {
          this.filteredApps = response.data;
          this.filterApps(this.filteredApps);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.$buefy.dialog.alert("Applications not found");
            this.$router.push("/");
          }
        })
    },
    filterApps(apps) {
      this.pendingApps = apps.filter(
            (app) => app.status == "Pending"
          );
      this.approvedApps = apps.filter(
            (app) => app.status == "Approved"
          );
      this.rejectedApps = apps.filter(
            (app) => app.status == "Rejected"
          );
          console.log(this.pendingApps)
    },
    approveApp(applicationId, renterId, propertyId){
        this.$buefy.dialog.confirm({
          message: "Are you sure you want to approve?",
          onConfirm: () => 
          {this.app.applicationId = applicationId;
          this.app.renterId = renterId;
          this.app.propertyId = propertyId;
          this.app.status = 'Approved'
          appService.approveApplication(this.app)
        .then(response => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Application successfully approved");
              this.retrieveApps();
            }
          })
          .catch(error => {
            if (error.response) {
              this.$buefy.dialog.alert(`Error approving application. Response received was ${error.response.statusText}`)
            }
          });}
        }
          )
      
      
    },
      rejectApp(applicationId){
        this.$buefy.dialog.confirm({
          message: "Are you sure you want to reject?",
          onConfirm: () => 
          {appService.rejectApplication(applicationId)
        .then(response => {
            if (response.status === 200) {
              this.$buefy.dialog.alert("Application successfully rejected");
              this.retrieveApps();
            }
          })
          .catch(error => {
            if (error.response) {
              this.$buefy.dialog.alert(`Error rejecting application. Response received was ${error.response.statusText}`)
            }
          });}
        })
        
      
    }
  },
//   computed: {
//     apps() {
//       return this.$store.state.apps;
//     }
//   },
  created() {
    this.retrieveApps();
  },
}

</script>

<style scoped>
#landlord {
  padding-top: 50px;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "pending scheduled completed";
}
#pending {
  grid-area: pending;
  border-right: solid 4px #031926;
}
#approved {
  grid-area: scheduled;
  border-right: solid 4px #031926;
}
#rejected {
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
#pend > .btn {
  background-color: #9dbebb91;
  color: #031926;
  margin-right: 15px;
}
</style>