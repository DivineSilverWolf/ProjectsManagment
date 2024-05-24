<script>
import axios from "axios";
export default {
    components: {},
    // тут обьявляем пропсы - данные, которы передаем в app.vue
    props : {

    },
    // здесь обьявляем данные, которые будем использовать
    data() {
        return {
            post: "Post",
            companies: [],
            projectName: "",
            projectStartDate: null,
            projectEndDate: null,
            companyBuyer: null,
            companyExecutor: null,
            employeeLeader: null,
            employees: {},
            projectPriority: 0
        }
    },
    //  тут обьявлем методы
    methods : {
        postProjectClick(event) {
            let validationNotNull = this.projectStartDate != null && this.companyBuyer != null && this.companyExecutor != null  && this.employeeLeader != null
            let validationDate = this.projectEndDate == null || (this.projectStartDate < this.projectEndDate)
            if(validationNotNull && validationDate){
                axios.post('http://localhost:32768/api/Projects', {
                    name: this.projectName,
                    dateStart: this.projectStartDate,
                    dateEnd: this.projectEndDate,
                    companyBuyer: this.companyBuyer,
                    companyExecutor: this.companyExecutor,
                    leader: this.employeeLeader,
                    projectPriority: this.projectPriority
                })
                    .then(function (response) {
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        getCompanies(){
            axios.get('http://localhost:32768/api/Companies')
                .then( (response) => {
                    console.log(response);
                    this.companies = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        getEmployees(event){
            axios.get('http://localhost:32768/api/Employees/' + event.target.value)
                .then( (response) => {
                    console.log(response);
                    this.employees = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        getAllEmployees(){
            axios.get('http://localhost:32768/api/Employees')
                .then( (response) => {
                    console.log(response);
                    this.employees = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
    },
    mounted() {
        this.getAllEmployees();
        this.getCompanies();
    }
};
</script>

<template>
    <div class="container">
        <form>
            <div class="row">
                <h4>Project</h4>
                <div class="input-group input-group-icon">
                    <input type="text" placeholder="Name project" v-model="projectName"/>
                    <div class="input-icon"><i class="name-project"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <h4>Start date project</h4>
                    <input type="date" v-model="projectStartDate"/>
                    <div class="input-icon"><i class="start-date"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <h4>End date project</h4>
                    <input type="date" v-model="projectEndDate"/>
                    <div class="input-icon"><i class="end-date"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <select id="company-buyer" name="company-buyer" v-model="companyBuyer">
                        <option value="" disabled selected>Select company buyer</option>
                        <option v-for="company in companies" :value="company">{{company.name}}</option>
                    </select>
                    <div class="input-icon"><i class="end-date"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <select  id="company-executor" name="company-executor" v-model="companyExecutor">
                        <option value="" disabled selected>Select company executor</option>
                        <option v-for="company in companies" :value="company">{{company.name}}</option>
                    </select>
                    <div class="input-icon"><i class="end-date"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <select id="employee-leader" name="employee-leader" v-model="employeeLeader" onchange="document.getElementById('textInput')">
                        <option value="" disabled selected>Select employee leader project</option>
                        <option v-for="employee in employees" :value="employee">
                            {{employee.name}} {{employee.surname}} {{employee.patronymicName}} {{employee.mailingAddress}}</option>
                    </select>
                    <input @input="getEmployees" type="text" id="textInput" placeholder="Введите своё значение"/>
                    <div class="input-icon"><i class="end-date"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <input type="number" placeholder="Project priority" v-model="projectPriority"/>
                    <div class="input-icon"><i class="priority-project"></i></div>
                </div>
            </div>
            <button @click.prevent="postProjectClick">{{ post }}</button>
        </form>
    </div>
</template>

<style scoped>
/* 64ac15 */
*,
*:before,
*:after {
    box-sizing: border-box;
}
body {
    padding: 1em;
    font-family: "Open Sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
    font-size: 15px;
    color: #b9b9b9;
    background-color: #e3e3e3;
}
h4 {
    color: #f0a500;
}
input,
input[type="radio"] + label,
input[type="checkbox"] + label:before,
select option,
select {
    width: 100%;
    padding: 1em;
    line-height: 1.4;
    background-color: #f9f9f9;
    border: 1px solid #e5e5e5;
    border-radius: 3px;
    -webkit-transition: 0.35s ease-in-out;
    -moz-transition: 0.35s ease-in-out;
    -o-transition: 0.35s ease-in-out;
    transition: 0.35s ease-in-out;
    transition: all 0.35s ease-in-out;
}
input:focus {
    outline: 0;
    border-color: #bd8200;
}
input:focus + .input-icon i {
    color: #f0a500;
}
input:focus + .input-icon:after {
    border-right-color: #f0a500;
}
input[type="radio"] {
    display: none;
}
input[type="radio"] + label,
select {
    display: inline-block;
    width: 50%;
    text-align: center;
    float: left;
    border-radius: 0;
}
input[type="radio"] + label:first-of-type {
    border-top-left-radius: 3px;
    border-bottom-left-radius: 3px;
}
input[type="radio"] + label:last-of-type {
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px;
}
input[type="radio"] + label i {
    padding-right: 0.4em;
}
input[type="radio"]:checked + label,
input:checked + label:before,
select:focus,
select:active {
    background-color: #f0a500;
    color: #fff;
    border-color: #bd8200;
}
input[type="checkbox"] {
    display: none;
}
input[type="checkbox"] + label {
    position: relative;
    display: block;
    padding-left: 1.6em;
}
input[type="checkbox"] + label:before {
    position: absolute;
    top: 0.2em;
    left: 0;
    display: block;
    width: 1em;
    height: 1em;
    padding: 0;
    content: "";
}
input[type="checkbox"] + label:after {
    position: absolute;
    top: 0.45em;
    left: 0.2em;
    font-size: 0.8em;
    color: #fff;
    opacity: 0;
    font-family: FontAwesome;
    content: "\f00c";
}
input:checked + label:after {
    opacity: 1;
}
select {
    height: 3.4em;
    line-height: 2;
}
select:first-of-type {
    border-top-left-radius: 3px;
    border-bottom-left-radius: 3px;
}
select:last-of-type {
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px;
}
select:focus,
select:active {
    outline: 0;
}
select option {
    color: #000000;
}
.input-group {
    margin-bottom: 1em;
    zoom: 1;
}
.input-group:before,
.input-group:after {
    content: "";
    display: table;
}
.input-group:after {
    clear: both;
}
.input-group-icon {
    position: relative;
}
.input-group-icon input {
    padding-left: 4.4em;
}
.input-group-icon .input-icon {
    position: absolute;
    top: 0;
    left: 0;
    width: 3.4em;
    height: 3.4em;
    line-height: 3.4em;
    text-align: center;
    pointer-events: none;
}
.input-group-icon .input-icon:after {
    position: absolute;
    top: 0.6em;
    bottom: 0.6em;
    left: 3.4em;
    display: block;
    border-right: 1px solid #e5e5e5;
    content: "";
    -webkit-transition: 0.35s ease-in-out;
    -moz-transition: 0.35s ease-in-out;
    -o-transition: 0.35s ease-in-out;
    transition: 0.35s ease-in-out;
    transition: all 0.35s ease-in-out;
}
.input-group-icon .input-icon i {
    -webkit-transition: 0.35s ease-in-out;
    -moz-transition: 0.35s ease-in-out;
    -o-transition: 0.35s ease-in-out;
    transition: 0.35s ease-in-out;
    transition: all 0.35s ease-in-out;
}
.container {
    max-width: 38em;
    padding: 1em 3em 2em 3em;
    margin: 0em auto;
    background-color: #fff;
    border-radius: 4.2px;
    box-shadow: 0px 3px 10px -2px rgba(0, 0, 0, 0.2);
}
.row {
    zoom: 1;
}
.row:before,
.row:after {
    content: "";
    display: table;
}
.row:after {
    clear: both;
}
.col-half {
    padding-right: 10px;
    float: left;
    width: 50%;
}
.col-half:last-of-type {
    padding-right: 0;
}
.col-third {
    padding-right: 10px;
    float: left;
    width: 33.33333333%;
}
.col-third:last-of-type {
    padding-right: 0;
}
@media only screen and (max-width: 540px) {
    .col-half {
        width: 100%;
        padding-right: 0;
    }
}

</style>
