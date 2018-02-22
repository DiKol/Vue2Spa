import 'bootstrap/dist/css/bootstrap.css';
import datePicker from 'vue-bootstrap-datetimepicker';
import 'eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css';

export default {
    data() {
        return {
            date1: new Date(),
            config1: {
                format: 'L'
            },
            date2: new Date(),
            config2: {
                format: 'LT'
            },
            items: null
        }
    },

    components: {
        datePicker
    },

    methods: {

        add: function (event) {
            try {

                this.$refs.title.value = "";
                this.$refs.details.value = "";
                showNew();

            } catch (error) {
                console.log(error)
            }

        },

        edit: function (id, event) {
            try {
                this.$http.post('/api/ToDo/edit', 'id=' + id)
                    .then(responce => {
                        this.$refs.title.value = responce.data.title;
                        $("#datestr").val(responce.data.dueDatePart);
                        $("#timestr").val(responce.data.dueTimePart);
                        this.$refs.details.value = responce.data.details;
                    });
                this.$refs.itemID.value = id;

                showEdit();

            } catch (error) {
                console.log(error)
            }

        },

        remove: function (id, event) {
            try {
                this.$http.post('/api/ToDo/remove', 'id=' + id)
                    .then(responce => {
                        let response1 = this.$http.get('/api/ToDo/get')
                            .then
                            (response1 => { this.items = response1.data; })
                    }
                    )
            } catch (error) {
                console.log(error)
            }
        },


        savenew: function (event) {
            try {
                var title = this.$refs.title.value;
                var datestr = this.$refs.datestr.value.toDateString();
                var timestr = this.$refs.timestr.value.toString();
                var details = this.$refs.details.value;

                this.$http.post('/api/ToDo/add', 'title=' + title + '&date=' + datestr + '&time=' + timestr + '&details=' + details)
                    .then(responce => {
                        let response1 = this.$http.get('/api/ToDo/get')
                            .then
                            (response1 => { this.items = response1.data; })
                    }
                    );
            } catch (error) {
                console.log(error)
            }

        },

        save: function (event) {
            try {
                var itemId = this.$refs.itemID.value;
                var title = this.$refs.title.value;
                var datestr = this.$refs.datestr.value.toDateString();
                var timestr = this.$refs.timestr.value.toString();
                var details = this.$refs.details.value;

                this.$http.post('/api/ToDo/update', 'id=' + itemId + '&title=' + title + '&date=' + datestr + '&time=' + timestr + '&details=' + details)
                    .then(responce => {
                        let response1 = this.$http.get('/api/ToDo/get')
                            .then
                            (response1 => { this.items = response1.data; })
                    }
                    );
            } catch (error) {
                console.log(error)
            }
        }

    },


    async created() {
        try {
            let response = await this.$http.get('/api/ToDo/get');
            this.items = response.data;
        } catch (error) {
            console.log(error)
        }
    }
}

function showNew() {
    $("#pEdit").show();
    $("#bSaveNew").show();
    $("#bSave").hide();
}


function showEdit() {
    $("#pEdit").show();
    $("#bSaveNew").hide();
    $("#bSave").show();
}
