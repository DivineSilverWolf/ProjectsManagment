<script>

import {defineComponent} from "vue";
import CardForAddProject from "@/components/CardForAddProject.vue";
import CardForAddProjectEmployees from "@/components/CardForAddProjectEmpoyees.vue";

export default defineComponent({
    components: {CardForAddProject, CardForAddProjectEmployees},
    data() {
        return {
            counter: 0,
            selectedCard: 'selectedCardForProject',
        }
    }
})
</script>

<template>
    <div class="SelectedCard">
        <select id="select-card" name="select-card" v-model="selectedCard">
            <option value="" disabled selected>Select workspaces</option>
            <option value="selectedCardForProject">Select add project workspaces</option>
            <option value="selectedCardForProjectEmployees">Select add employee in project workspaces</option>
        </select>
        <div class="input-icon"><i class="end-date"></i></div>
        <CardForAddProject v-if="selectedCard === 'selectedCardForProject'"></CardForAddProject>
        <CardForAddProjectEmployees v-else-if="selectedCard === 'selectedCardForProjectEmployees'"></CardForAddProjectEmployees>
    </div>
</template>

<style scoped>
*{font-size: 18px}
.SelectedCard { background-color: #282828; padding: 10px; border-radius: 5px; margin: 10px 0; }

.input-icon { position: relative; display: inline-block; }

.input-icon i { position: absolute; top: 50%; transform: translateY(-50%); right: 10px; }

#select-card { width: 100%; padding: 5px; border: none; border-radius: 5px; }

.SelectedCard select:focus { outline: none; }
</style>
