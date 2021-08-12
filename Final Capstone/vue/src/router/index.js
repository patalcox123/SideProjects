import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import Properties from '@/views/Properties.vue'
import Card from '@/views/Card.vue'
import AddProperty from '@/views/AddProperty.vue'
import AddImages from '@/views/AddImages.vue'
import MyProperties from '@/views/MyProperties.vue'
import MyMaintenance from '@/views/MyMaintenance.vue'
import LandlordProperty from '@/views/LandlordProperty.vue'
import EditProperty from '@/views/EditProperty.vue'
import EditImages from '@/views/EditRemoveImages.vue'
import MaintenanceCard from '@/views/TaskCard.vue'
import EditTask from '@/views/EditTask.vue'
import AddMaintenanceRequest from '@/views/AddMaintenanceRequest.vue'
import PropertyApplications from '@/views/PropertyApplications.vue'
import MyEmployeees from '@/views/MyEmployees.vue'
import MyInfo from '@/views/MyInfo.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/property",
      name: "properties",
      component: Properties,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/property/:propertyId",
      name: 'Card',
      component: Card,
      meta: {
        requiresAuth: false
      }

    },
    {
      path: "/addproperty",
      name: 'addproperty',
      component: AddProperty,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/images",
      name: "images",
      component: AddImages
    },
    {
      path: "/myProperties",
      name: "myproperties",
      component: MyProperties,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myProperties/:propertyId",
      name: 'landlordproperty',
      component: LandlordProperty,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myProperties/:propertyId/edit",
      name: 'editproperty',
      component: EditProperty,
      meta:{
        requiresAuth: true
      }

    },
    {
      path: "/myMaintenance",
      name: "mymaintenance",
      component: MyMaintenance,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myMaintenance/:taskId",
      name: 'landlord-task',
      component: MaintenanceCard,
      meta: {
        requiresAuth: true
      }
    },
    {
    path: "/myMaintenance/:taskId/edit",
    name: 'editrequest',
    component: EditTask,
    meta:{
      requiresAuth: true
    }
    },
    {
      path: "/myProperties/:propertyId/editImages",
      name: 'editimages',
      component: EditImages,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myMaintenance/addTask",
      name: 'addrequest',
      component: AddMaintenanceRequest,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myApplications",
      name: 'applications',
      component: PropertyApplications,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myEmployees",
      name: 'employees',
      component: MyEmployeees,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/myInfo",
      name: 'info',
      component: MyInfo,
      meta: {
        requiresAuth: true
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
