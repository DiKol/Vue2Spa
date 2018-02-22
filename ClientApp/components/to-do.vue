<template>
    <div>
        <div v-if="!items" class="text-center">
            <p>
                <em>Loading...</em>
            </p>
            <h1>
                <icon icon="spinner" pulse=""/>
            </h1>
        </div>
        <div class="pa">
            <a class="btn btn-outline-primary" role="button" @click="add">+</a>
        </div>
        <div class="pa-none" id="pEdit" ref="pEdit">
            <table class="table" v-if="items">
                <thead >
                    <tr>
                        <th>To Do</th>
                        <th>Due Date</th>
                        <th>Details</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="bg-white" >
                        <td>
                            <input type="hidden" id="itemID" ref="itemID" />
                            <input type="text" class="form-control" id="title" ref="title" />
                        </td>
                        <td>
                            <date-picker v-model="date1" :config="config1" id="datestr" ref="datestr"></date-picker>
                            <date-picker v-model="date2" :config="config2" id="timestr" ref="timestr"></date-picker>
                        </td>
                        <td>
                            <input type="text" class="form-control" id="details" ref="details" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="pa">
            <a class="btn btn-outline-success bt-d" role="button" @click="savenew" ref="bSaveNew" id="bSaveNew">Add</a>
            <a class="btn btn-outline-success bt-d" role="button" @click="save" ref="bSave" id="bSave">Update</a>
        </div>

        <table class="table" v-if="items">
            <thead >
                <tr>
                    <th>ID</th>
                    <th>To Do</th>
                    <th>Due Date</th>
                    <th>Due Time</th>
                    <th>Details</th>
                </tr>
            </thead>
            <tbody>
                <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(item, index) in items" :key="index">
                    <td>{{ item.id }}</td>
                    <td>{{ item.title }}</td>
                    <td>{{ item.dueDatePart }}</td>
                    <td>{{ item.dueTimePart }}</td>
                    <td>{{ item.details }}</td>
                    <td>
                        <a class="btn btn-outline-info" href="#" role="button" @click="edit(item.id)">Edit</a>
                        <a class="btn btn-outline-danger" href="#" role="button" @click="remove(item.id)">Delete</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script src="./js/to-do.js"></script>
<style src="./css/to-do.css"></style>
