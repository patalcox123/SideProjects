<template>
  <div>
    <landlord-maintenance v-if="$store.state.user.role == 'landlord'"/>
    <employee-maintenance v-if="$store.state.user.role == 'employee'"/>
    <renter-maintenance v-if="$store.state.user.role == 'renter'" />
  </div>
</template>

<script>
import RenterMaintenance from '@/components/RenterMaintenance.vue'
import EmployeeMaintenance from '../components/EmployeeMaintenance.vue'
import LandlordMaintenance from '../components/LandlordMaintenance.vue'

export default {
    components: {
        LandlordMaintenance,
        EmployeeMaintenance,
        RenterMaintenance,
        
    }
}
</script>

<style>
html {
  padding-top: 50px;
}
</style>
